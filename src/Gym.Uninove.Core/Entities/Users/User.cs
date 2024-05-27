using System.ComponentModel.DataAnnotations;

namespace Gym.Uninove.Core.Entities.Users
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // TODO: Definir Enum para Role - Admin ou Default
        public string Role { get; set; }


        // TODO: Foreign Keys Members
        public Membership Membership { get; set; }
        public int MembershipId { get; set; }

    }
}
