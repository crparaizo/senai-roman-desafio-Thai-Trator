using System;
using System.Collections.Generic;

namespace Senai.Roman.WebApi.Domains
{
    public partial class Temas
    {
        public Temas()
        {
            Projetos = new HashSet<Projetos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? IdSituacao { get; set; }

        public Situacoes IdSituacaoNavigation { get; set; }
        public ICollection<Projetos> Projetos { get; set; }
    }
}
