using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTU.App.Data.Entities;
using KSTU.App.Data.Interfaces;

namespace KSTU.App.Data.Repositories
{
    public class ApplicationRepository<TEntity> : IApplicationRepository<TEntity> where TEntity : BaseApplicationEntity
    {
        public async Task<TEntity> CreateOrUpdate(TEntity entity, long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TEntity> FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IQueryable<TEntity>> ListAll()
        {
            throw new System.NotImplementedException();
        }
    }
}