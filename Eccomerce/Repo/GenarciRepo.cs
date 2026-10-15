
using Eccomerce.App_Context;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce.Repo
{
    public class GenarciRepo<T> : IGenariceRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        public GenarciRepo(AppDbContext cotext)
        {
            _context = cotext;
            _dbSet = _context.Set<T>();

        }
        public async Task Add(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public  void Delete(int Id)
        {
            var entity = _dbSet.Find(Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public  void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
