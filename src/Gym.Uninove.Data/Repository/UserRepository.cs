
using Gym.Uninove.Core.Entities.Users;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;

namespace Gym.Uninove.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly GymContext _context;

        public UserRepository(GymContext context) : base(context)
        {
            this._context = context;
        }

    }
}
