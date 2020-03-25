using System.Linq;
using System.Collections.Generic;
using Senai.Users.WebApi.Contexts;
using Senai.Users.WebApi.Domains;
using Senai.Users.WebApi.Interfaces;

namespace Senai.Users.WebApi.Repositories
{
    public class ProfissaoRepository : IProfissaoRepository
    {
        public void Atualizar(Profissoes profissao)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                Profissoes ProfissaoBuscada = ctx.Profissoes.FirstOrDefault(item => item.IdProfissao == profissao.IdProfissao);
                ProfissaoBuscada.Nome = profissao.Nome;

                ctx.Profissoes.Update(ProfissaoBuscada);
                ctx.SaveChanges();
            }
        }

        public Profissoes BuscarPorId(int id)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                return ctx.Profissoes.FirstOrDefault(item => item.IdProfissao == id);
            }
        }

        public Profissoes Cadastrar(Profissoes profissao)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                ctx.Profissoes.Add(profissao);
                ctx.SaveChanges();
                return profissao;
            }
        }

        public void Deletar(int id)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                Profissoes ProfissaoBuscada = ctx.Profissoes.FirstOrDefault(item => item.IdProfissao == id);

                ctx.Profissoes.Remove(ProfissaoBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Profissoes> Listar()
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                return ctx.Profissoes.ToList();
            }
        }
    }
}
