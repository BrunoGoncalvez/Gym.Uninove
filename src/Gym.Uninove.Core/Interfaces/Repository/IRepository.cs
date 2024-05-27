
namespace Gym.Uninove.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(int id);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<bool> SaveChangesAsync();

    }
}
