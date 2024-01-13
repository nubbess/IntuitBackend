using IntuitChallenge.Data;
using IntuitChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IntuitChallenge.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        internal DbSet<T> dbSet;
        private readonly ClientesDbContext _db;
        public GenericService(ClientesDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task Create(T Entidad)
        {
            await dbSet.AddAsync(Entidad);
            await Save();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filtro = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked) query = query.AsNoTracking();

            if (filtro != null) query = query.Where(filtro);

            return await query.FirstOrDefaultAsync();
        }
        
        public async Task Delete(T Entidad)
        {
            dbSet.Remove(Entidad);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
