using Senai.Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Interfaces
{
    interface IProjetoRepository
    {
        void CadastrarProjeto(Projetos projeto);

        List<Projetos> ListarProjetos();
    }
}
