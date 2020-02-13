using System.Linq;
using System.Threading.Tasks;
using KSTU.App.Data.Entities;

namespace KSTU.App.Data.Interfaces
{
    public interface IApplicationRepository<TEntity> where TEntity : BaseApplicationEntity
    {
        Task<TEntity> FindById(long id);
        Task<IQueryable<TEntity>> ListAll();
        Task<TEntity> CreateOrUpdate(TEntity entity, long id);
    }
}