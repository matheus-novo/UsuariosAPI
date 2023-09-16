using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Dtos;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto userDto)
        {
            await _usuarioService.Cadastrar(userDto);
            return Ok("Usuário Cadastrado!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioDto userDto)
        {
            var token = await _usuarioService.Login(userDto);
            return Ok(token);
        }
    }
}
