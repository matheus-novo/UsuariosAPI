﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class AcessoController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get() {
            return Ok();
        }
    }
}
