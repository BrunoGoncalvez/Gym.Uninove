using Gym.Uninove.Core.Entities;
using Gym.Uninove.Core.Interfaces.Repository;
using Gym.Uninove.Data.Context;

namespace Gym.Uninove.Data.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {

        private readonly GymContext _context;

        public TeacherRepository(GymContext context) : base(context)
        {
            this._context = context;
        }

    }
}
