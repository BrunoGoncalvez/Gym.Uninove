using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gym.Uninove.Data.Repository
{
    public class GymBranchRepository : Repository<GymBranch>, IGymBranchRepository
    {

        private readonly GymContext _context;

        public GymBranchRepository(GymContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<GymBranch> GetGymWithAddress(int id)
        {
            var gym = await _context.Gyms.AsNoTracking().Include(g => g.Address).FirstOrDefaultAsync(g => g.Id == id);
            return gym;
        }

        public void ClearChangeTracker()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
