using IntuitChallenge.Models;
using System.Linq.Expressions;

namespace IntuitChallenge.Services
{
    public interface IGenericService <T> where T : class
    {

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filtro = null);
        // el 'Get' general tiene posibilidad de filtrar;
        Task<T> Get(Expression<Func<T, bool>>? filtro = null, bool tracked = true);
        Task Create(T Entidad);
        Task Delete(T Entidad);
        Task Save();
    }
}
