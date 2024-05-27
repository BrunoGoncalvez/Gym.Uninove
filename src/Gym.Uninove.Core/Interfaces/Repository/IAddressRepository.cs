using Gym.Uninove.Core.Entities;

namespace Gym.Uninove.Core.Interfaces.Repository
{
    public interface IAddressRepository : IRepository<Address>
    {

        void ClearChangeTracker();

    }

}
