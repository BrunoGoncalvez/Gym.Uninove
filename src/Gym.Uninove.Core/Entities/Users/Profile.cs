
namespace Gym.Uninove.Core.Entities.Users
{
    public class Profile
    {
        // TODO: Adicionar Imagem ao Profile
        public int Id { get; set; }

        public string Name { get; set; }

        //public ImageUrl? Photo { get; set; }

        public string Description { get; set; }

        public string Occupation { get; set; }

        // Foreign Keys
        public User User { get; set; }

        public int UserId { get; set; }

    }
}
