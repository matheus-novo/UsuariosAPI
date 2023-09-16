using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using UsuariosAPI.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public UsuarioService() { }


        public async Task Cadastrar(CreateUsuarioDto userDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(userDto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, userDto.Password);

            if (!resultado.Succeeded)
            {
                var erros = resultado.Errors.Select(e => e.Description).ToString();
                throw new ApplicationException(erros);
            }
        }

        public async Task<string> Login(LoginUsuarioDto userDto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);

            if (!resultado.Succeeded)
            { 
                throw new ApplicationException("Usuario não autenticado!");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(usuario => usuario.NormalizedUserName == userDto.Username.ToUpper());


            var token = _tokenService.GerarToken(usuario);

            return token;
        }
    }
}
