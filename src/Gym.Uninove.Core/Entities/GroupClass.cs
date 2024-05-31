
using Gym.Uninove.Core.Entities.Users;

namespace Gym.Uninove.Core.Entities
{
    public class GroupClass
    {

        public int Id { get; set; }

        public string Name { get; set; } 

        // TODO: Descomentae Students
        //public ICollection<User> Students { get; set; }


        // TODO: Checar Foreign Keys
        public Teacher Instructor { get; set; }
        public int TeacherId { get; set; }

    }
}
