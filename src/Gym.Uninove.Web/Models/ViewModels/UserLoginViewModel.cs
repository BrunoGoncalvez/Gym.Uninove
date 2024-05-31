using System.ComponentModel.DataAnnotations;

namespace Gym.Uninove.Web.Models.ViewModels
{
    public class UserLoginViewModel
    {

        [Required(ErrorMessage = "*Campo obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Campo obrigatório")]
        public string Password { get; set; }

    }
}
