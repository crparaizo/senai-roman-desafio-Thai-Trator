using System;
using System.Collections.Generic;

namespace Senai.Roman.WebApi.Domains
{
    public partial class Equipes
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<UsuariosEquipes> UsuariosEquipes { get; set; }
    }
}
