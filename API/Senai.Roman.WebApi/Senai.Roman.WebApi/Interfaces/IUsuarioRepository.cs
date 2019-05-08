using Senai.Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
