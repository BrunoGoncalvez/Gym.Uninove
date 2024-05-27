
using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;

namespace Gym.Uninove.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {

        private readonly GymContext _context;

        public AddressRepository(GymContext context) : base(context)
        {
            this._context = context;
        }

        public void ClearChangeTracker()
        {
            _context.ChangeTracker.Clear();
        }

    }
}
