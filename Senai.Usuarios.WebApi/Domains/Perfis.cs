using System;
using System.Collections.Generic;

namespace Senai.Usuarios.WebApi.Domains
{
    public partial class Perfis
    {
        public Perfis()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPerfil { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
