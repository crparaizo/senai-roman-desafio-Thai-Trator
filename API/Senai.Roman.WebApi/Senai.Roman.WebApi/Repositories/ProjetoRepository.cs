using Microsoft.EntityFrameworkCore;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        public void CadastrarProjeto(Projetos projeto)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Projetos.Add(projeto);
                ctx.SaveChanges();
            }
        }

        public List<Projetos> ListarProjetos()
        {
            using (RomanContext ctx = new RomanContext())
            {
                List<Projetos> listaProjetos = ctx.Projetos.Include(x => x.IdTemaNavigation).Include(y => y.IdUsuarioNavigation).ToList();

                foreach (var item in listaProjetos)
                {
                    item.IdTemaNavigation.Projetos = null;
                    item.IdUsuarioNavigation.Projetos = null;
                    item.IdUsuarioNavigation.Senha = null;
                }

                return listaProjetos;
            }
        }
    }
}
