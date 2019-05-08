using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Roman.WebApi.Domains;
using Senai.Roman.WebApi.Interfaces;
using Senai.Roman.WebApi.Repositories;

namespace Senai.Roman.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TemasController : ControllerBase
    {
        private ITemaRepository TemaRepository { get; set; }

        public TemasController()
        {
            TemaRepository = new TemaRespository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(TemaRepository.ListarTemas());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro!" + ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CadastrarTema(Temas tema)
        {
            tema.IdSituacao = 1;

            try
            {
                TemaRepository.CadastrarTema(tema);
                return Ok(new { mensagem = "Tema Cadastrado!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro!" + ex.Message });
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult AlterarSituacao(Temas tema)
        {
            try
            {
                Temas TemaAlterado = TemaRepository.BuscarTemaPorId(tema.Id);

                TemaAlterado.IdSituacao = tema.IdSituacao;
                TemaRepository.AlterarSituacaoTema(TemaAlterado);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Error" + ex.Message });
            }
        }
    }
}