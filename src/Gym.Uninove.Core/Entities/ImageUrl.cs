
using Gym.Uninove.Core.Entities.Users;

namespace Gym.Uninove.Core.Entities
{
    public class ImageUrl
    {

        public int Id { get; set; }

        public string Url { get; set; }

        public string Path { get; set; }

        // TODO: Foreign Keys
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }

    }
}
