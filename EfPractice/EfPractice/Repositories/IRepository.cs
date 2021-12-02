using System.Linq;
using System.Threading.Tasks;

namespace EfPractice.Repositories
{
    public interface IRepository
    {
        Task<long> Create<T>(T entity) where T : IEntity;
        Task Update<T>(T entity) where T : IEntity;
        Task Delete<T>(T entity) where T : IEntity;
        IQueryable<T> Query<T>() where T : class, IEntity;
    }
}