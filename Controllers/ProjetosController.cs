using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exo_WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Exo_WebApi.Models;

namespace Exo_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository
 _projetoRepository;
        public ProjetosController(ProjetoRepository
        projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_projetoRepository.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            _projetoRepository.Cadastrar(projeto);
            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarporId(int id)
        {
            Projeto projeto = _projetoRepository.BuscarporId(id);
            if(projeto == null)
            {
                return NotFound();
            }
            return Ok(projeto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            _projetoRepository.Atualizar(id, projeto);
            return StatusCode(204);
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _projetoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                
                return BadRequest();
            }
        }

    }
}