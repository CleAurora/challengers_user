using System.Linq;
using System.Collections.Generic;
using Senai.Users.WebApi.Contexts;
using Senai.Users.WebApi.Domains;
using Senai.Users.WebApi.Interfaces;
using Senai.Users.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace Senai.Users.WebApi.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        public void Atualizar(Usuarios usuario)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(item => item.IdUsuario == usuario.IdUsuario);

                UsuarioBuscado.Nome = usuario.Nome;
                UsuarioBuscado.Email = usuario.Email;
                UsuarioBuscado.Senha = usuario.Senha;
                UsuarioBuscado.SitePessoal = usuario.SitePessoal;
                UsuarioBuscado.Imagem = usuario.Imagem;
                UsuarioBuscado.IdProfissao = usuario.IdProfissao;
                UsuarioBuscado.IdPerfil = usuario.IdPerfil;

                ctx.Usuarios.Update(UsuarioBuscado);
                ctx.SaveChanges();

            }
        }

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.Include(x => x.IdPerfilNavigation).FirstOrDefault(item => item.Email == login.Email && item.Senha == HashValue(login.Senha));

                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                return ctx.Usuarios.FirstOrDefault(item => item.IdUsuario == id);
            }
        }

        public Usuarios Cadastrar(Usuarios usuario)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
                return usuario;
            }
        }

        public void Deletar(int id)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(item => item.IdUsuario == id);
                ctx.Usuarios.Remove(UsuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public static string HashValue(string value)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes;
            using (HashAlgorithm hash = SHA1.Create())
                hashBytes = hash.ComputeHash(encoding.GetBytes(value));

            StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }
    }    
}

