
using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;

namespace Gym.Uninove.Data.Repository
{
    public class MembershipRepository : Repository<Membership>, IMembershipRepository
    {

        private readonly GymContext _context;

        public MembershipRepository(GymContext context) : base(context) 
        {
            this._context = context;
        }

    }
}
