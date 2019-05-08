using Microsoft.EntityFrameworkCore;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Repositories
{
    public class TemaRespository : ITemaRepository
    {
        public void AlterarSituacaoTema(Temas tema)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Temas.Update(tema);
                ctx.SaveChanges();
            }
        }

        public void CadastrarTema(Temas tema)
        {
            using (RomanContext ctx = new RomanContext())
            {
                ctx.Temas.Add(tema);
                ctx.SaveChanges();
            }
        }

        public List<Temas> ListarTemas()
        {
            using (RomanContext ctx = new RomanContext())
            {
                List<Temas> listaTemas = ctx.Temas.Include(x => x.IdSituacaoNavigation).ToList();

                foreach (var item in listaTemas)
                {
                    item.IdSituacaoNavigation.Temas = null;
                }

                return listaTemas;
            }
        }

        public Temas BuscarTemaPorId(int id)
        {
            using (RomanContext ctx = new RomanContext())
            {
                // Consultas consultaProcurada = ctx.Consultas.Find(id);
                Temas consultaProcurada = ctx.Temas.Include(x => x.IdSituacaoNavigation).FirstOrDefault(x => x.Id == id);

                if (consultaProcurada == null)
                {
                    return null;
                }
                return consultaProcurada;
            }
        }
    }
}
