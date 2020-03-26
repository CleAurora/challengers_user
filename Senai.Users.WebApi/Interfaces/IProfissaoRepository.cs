using System.Collections.Generic;
using Senai.Users.WebApi.Domains;

namespace Senai.Users.WebApi.Interfaces
{
    public interface IProfissaoRepository
    {
        List<Profissoes> Listar();

        Profissoes BuscarPorId(int id);

        Profissoes Cadastrar(Profissoes profissao);

        void Atualizar(Profissoes profissao);

        void Deletar(int id);
    }
}
