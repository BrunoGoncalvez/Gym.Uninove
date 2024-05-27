using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;

namespace Gym.Uninove.Data.Repository
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {

        private readonly GymContext _context;

        public EquipmentRepository(GymContext context) : base(context)
        {
            this._context = context;
        }

    }
}
