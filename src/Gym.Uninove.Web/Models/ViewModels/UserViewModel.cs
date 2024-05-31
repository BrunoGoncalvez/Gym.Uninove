using Gym.Uninove.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gym.Uninove.Web.Models.ViewModels
{
    public class UserViewModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(8, ErrorMessage = "Senha deve ter 8 ou mais digitos.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não correspondem.")]
        [MinLength(8, ErrorMessage = "Senha deve ter 8 ou mais digitos.")]
        public string PasswordConfirmed { get; set; }

        [Required]
        public bool AcceptTerms { get; set; }

        public TypeUser Role { get; set; }

    }
}
