using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }

        //Aqui, pegamos as propriedades já criadas do Identity User
        public Usuario() : base() { }
    }
}
