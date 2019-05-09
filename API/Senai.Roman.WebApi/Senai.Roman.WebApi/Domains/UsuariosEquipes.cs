using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Domains
{
    public class UsuariosEquipes
    {
        public int IdUsuario { get; set; }
        public int IdEquipe { get; set; }

        public Usuarios IdUsuariosNavigation { get; set; }
        public Equipes IdEquipesNavigation { get; set; }

    }
}
