using System;
using System.Collections.Generic;

namespace Senai.Roman.WebApi.Domains
{
    public partial class Situacoes
    {
        public Situacoes()
        {
            Temas = new HashSet<Temas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Temas> Temas { get; set; }
    }
}
