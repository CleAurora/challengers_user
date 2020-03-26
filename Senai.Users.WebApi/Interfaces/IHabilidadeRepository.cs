using System.Collections.Generic;
using Senai.Users.WebApi.Domains;

namespace Senai.Users.WebApi.Interfaces
{
    public interface IHabilidadeRepository
    {
        List<Habilidades> Listar();

        Habilidades BuscarPorId(int id);

        Habilidades Cadastrar(Habilidades habilidade);

        void Atualizar(Habilidades habilidade);

        void Deletar(int id);
    }
}
