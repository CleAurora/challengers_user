using System.ComponentModel.DataAnnotations;

namespace Senai.Users.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
