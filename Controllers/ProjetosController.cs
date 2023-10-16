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


    }
}