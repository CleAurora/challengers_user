using System.Collections.Generic;
using Senai.Users.WebApi.Domains;
using Senai.Users.WebApi.ViewModels;

namespace Senai.Users.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        Usuarios Cadastrar(Usuarios usuario);

        Usuarios BuscarPorId(int id);

        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        void Atualizar(Usuarios usuario);

        void Deletar(int id);
    }
}
