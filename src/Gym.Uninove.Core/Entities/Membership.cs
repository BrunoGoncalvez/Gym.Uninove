using Gym.Uninove.Core.Entities.Users;

namespace Gym.Uninove.Core.Entities
{
    public class Membership
    {

        public int Id { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }


        // TODO: Descomentar Members
        //public ICollection<User> Members { get; set; }

    }
}
