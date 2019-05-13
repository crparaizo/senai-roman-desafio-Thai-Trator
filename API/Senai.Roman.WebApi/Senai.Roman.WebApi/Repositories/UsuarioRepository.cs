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

        public List<Usuarios> ListarUsuarios()
        {
            using (RomanContext ctx = new RomanContext())
            {
                List<Usuarios> listaUsuarios = ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).Include(x => x.UsuariosEquipes).Where(x => x.IdTipoUsuarioNavigation.Nome == "Professor").ToList();

                foreach (var item in listaUsuarios)
                {
                    item.IdTipoUsuarioNavigation.Usuarios = null;
                }

                return listaUsuarios;
            }
        }

        public List<Usuarios> BuscarUsuarioPorArea(string equipe)
        {
            using (RomanContext ctx = new RomanContext())
            {
                List<Usuarios> ListaUsuarioProcurado = ctx.Usuarios.Include(x => x.UsuariosEquipes).Include("UsuariosEquipes.Equipes").ToList();

                List<Usuarios> listaFiltrados = new List<Usuarios>();

                foreach (Usuarios item in ListaUsuarioProcurado)
                {
                    foreach(UsuariosEquipes usuarioEquip in item.UsuariosEquipes)
                    {
                        if (usuarioEquip.Equipes.Nome == equipe)
                        {
                            listaFiltrados.Add(item);
                        }
                    }
                }

                if (ListaUsuarioProcurado == null)
                {
                    return null;
                }
                return listaFiltrados;
            }
        }
    }
}
