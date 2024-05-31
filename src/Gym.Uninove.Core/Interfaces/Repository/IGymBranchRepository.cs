using Gym.Uninove.Core.Entities;

namespace Gym.Uninove.Core.Interfaces.Repository
{
    public interface IGymBranchRepository : IRepository<GymBranch>
    {

        Task<GymBranch> GetGymWithAddress(int id);

        Task<IEnumerable<GymBranch>> GetAllGymWithAddress();

        void ClearChangeTracker();

    }
}
