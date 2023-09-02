using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Dtos;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarUsuario(CreateUsuarioDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
