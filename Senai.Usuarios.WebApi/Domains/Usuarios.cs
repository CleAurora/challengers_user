using System;
using System.Collections.Generic;

namespace Senai.Usuarios.WebApi.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SitePessoal { get; set; }
        public string Imagem { get; set; }
        public int? IdProfissao { get; set; }
        public int? IdPerfil { get; set; }

        public virtual Perfis IdPerfilNavigation { get; set; }
        public virtual Profissoes IdProfissaoNavigation { get; set; }
    }
}
