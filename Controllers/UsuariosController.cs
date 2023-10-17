using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exo_WebApi.Models;
using Exo_WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


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
        // [HttpPost]
        // public IActionResult Cadastrar(Usuario usuario)
        // {
        //     _usuarioRepository.Cadastrar(usuario);
        //     return StatusCode(201);
        // }
        public IActionResult Post(Usuario usuario)
        {
            Usuario usuarioBuscado = _usuarioRepository.Login(usuario.Email,
            usuario.Senha);
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }
            // Se o usuário for encontrado, segue a criação do token.
            // Define os dados que serão fornecidos no token - Payload.
            var claims = new[]
            {
// Armazena na claim o e-mail usuário autenticado.
new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
// Armazena na claim o id do usuário autenticado.
new Claim(JwtRegisteredClaimNames.Jti,
usuarioBuscado.Id.ToString()),
};
            // Define a chave de acesso ao token.
            var key = new
            SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chaveautenticacao"));
            // Define as credenciais do token.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Gera o token.
            var token = new JwtSecurityToken(
            issuer: "exoapi.webapi", // Emissor do token.
            audience: "exoapi.webapi", // Destinatário do token.
            claims: claims, // Dados definidos acima.
            expires: DateTime.Now.AddMinutes(30), // Tempo de expiração.
            signingCredentials: creds // Credenciais do token.
            );
            // Retorna ok com o token.
            return Ok(
            new { token = new JwtSecurityTokenHandler().WriteToken(token) }
            );
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
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            _usuarioRepository.Atualizar(id, usuario);
            return StatusCode(204);
        }
        [Authorize]
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