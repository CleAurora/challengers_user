using System;
using System.Collections.Generic;

namespace Senai.Users.WebApi.Domains
{
    public partial class Profissoes
    {
        public Profissoes()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdProfissao { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
