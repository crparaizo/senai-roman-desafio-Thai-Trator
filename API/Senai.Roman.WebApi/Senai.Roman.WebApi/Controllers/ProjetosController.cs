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
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepository ProjetoRepository { get; set; }

        public ProjetosController()
        {
            ProjetoRepository = new ProjetoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ProjetoRepository.ListarProjetos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro!" + ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CadastrarProjeto(Projetos projeto)
        {
            try
            {
                ProjetoRepository.CadastrarProjeto(projeto);
                return Ok(new { mensagem = "Projeto Cadastrado!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro!" + ex.Message });
            }
        }
    }
}