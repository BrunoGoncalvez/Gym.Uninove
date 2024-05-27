using Gym.Uninove.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;


namespace Gym.Uninove.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            this._context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            this._dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = await this._dbSet.FindAsync(id);

            if (model == null) return false;

            this._dbSet.Remove(model);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            this._dbSet.Update(entity);
            await this._context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
