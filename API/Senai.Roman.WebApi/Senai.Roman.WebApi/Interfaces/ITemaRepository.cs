using Senai.Roman.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.WebApi.Interfaces
{
    interface ITemaRepository
    {
        void CadastrarTema(Temas tema);

        List<Temas> ListarTemas();

        void AlterarSituacaoTema(Temas tema);

        Temas BuscarTemaPorId(int id);

    }
}
