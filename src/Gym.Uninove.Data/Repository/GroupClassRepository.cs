using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;

namespace Gym.Uninove.Data.Repository
{
    public class GroupClassRepository : Repository<GroupClass>, IGroupClassRepository
    {

        private readonly GymContext _context;

        public GroupClassRepository(GymContext context) : base(context)
        {
            this._context = context;
        }

    }
}
