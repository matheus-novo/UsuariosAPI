using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        public UsuarioController(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto userDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(userDto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, userDto.Password);

            if (resultado.Succeeded)
            {
                return Ok("Usuário Cadastrado!");
            }
            else
            {
                var erros = resultado.Errors.Select(e => e.Description).ToList();
                return BadRequest(new { Mensagem = "Falha ao cadastrar usuário", Erros = erros });
            }
        }
    }
}
