using Microsoft.EntityFrameworkCore;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (RomanContext ctx = new RomanContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.Email == email && x.Senha == senha);

                if (usuarioProcurado == null)
                {
                    return null;
                }
                return usuarioProcurado;
            }
        }
    }
}
