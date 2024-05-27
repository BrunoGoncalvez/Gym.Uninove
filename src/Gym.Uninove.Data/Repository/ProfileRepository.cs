using Gym.Uninove.Core.Entities.Users;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;

namespace Gym.Uninove.Data.Repository
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {

        private readonly GymContext _context;

        public ProfileRepository(GymContext context) : base(context)
        {
            this._context = context;
        }

    }
}
