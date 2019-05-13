using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Domains
{
    [Table("USUARIOS_EQUIPES")]
    public class UsuariosEquipes
    {
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("ID_EQUIPE")]
        public int IdEquipe { get; set; }

        public Usuarios Usuarios { get; set; }
        public Equipes Equipes { get; set; }

    }
}
