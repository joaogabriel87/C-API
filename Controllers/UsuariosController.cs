using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exo_WebApi.Models;
using Exo_WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo_WebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuariosController(UsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarporId(int id)
        {
            Usuario usuario = _usuarioRepository.BuscaporId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            _usuarioRepository.Atualizar(id, usuario);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                
              return BadRequest();
            }
        }
    }   

}