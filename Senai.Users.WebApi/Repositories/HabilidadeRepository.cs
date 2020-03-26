using System.Collections.Generic;
using System.Linq;
using Senai.Users.WebApi.Contexts;
using Senai.Users.WebApi.Domains;
using Senai.Users.WebApi.Interfaces;

namespace Senai.Users.WebApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        public void Atualizar(Habilidades habilidade)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                Habilidades HabilidadeBuscada = ctx.Habilidades.FirstOrDefault(item => item.IdHabilidade == habilidade.IdHabilidade);
                HabilidadeBuscada.Nome = habilidade.Nome;

                ctx.Habilidades.Update(HabilidadeBuscada);
                ctx.SaveChanges();
            }
        }

        public Habilidades BuscarPorId(int id)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                return ctx.Habilidades.FirstOrDefault(item => item.IdHabilidade == id);
            }
        }

        public Habilidades Cadastrar(Habilidades habilidade)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                ctx.Habilidades.Add(habilidade);
                ctx.SaveChanges();
                return habilidade;
            }
        }

        public void Deletar(int id)
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                Habilidades HabilidadeBuscada = ctx.Habilidades.FirstOrDefault(item => item.IdHabilidade == id);

                ctx.Habilidades.Remove(HabilidadeBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Habilidades> Listar()
        {
            using (UsuarioContext ctx = new UsuarioContext())
            {
                return ctx.Habilidades.ToList();
            }
        }
    }
}
