using ERP.Core.Abstracts;
using ERP.Core.DAL.Entities;
using ERP.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Repositories.Base
{
    internal class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public virtual void AddOrUpdate(T model)
        {
            var repository = new RepositoryFactory().CreateGenericRepository<T>();
            Task.Run(async () => {
                var oldValue = await repository.GetFirstAsync(x => x.ID == model.ID);
                if (oldValue != null)
                {
                    await repository.UpdateAsync(oldValue, model);
                }
                else
                {
                    model.RecordStatus = BaseEntity.RecordStatusType.Active;
                    await repository.AddAsync(model);
                }
            }).Wait();
        }

        public virtual void Delete(T model)
        {
            var repository = new RepositoryFactory().CreateGenericRepository<T>();
            Task.Run(async () => {
                await repository.DeleteAsync(model);
            }).Wait();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> records = null;

            Task.Run(async () => {
                records = await new RepositoryFactory().CreateGenericRepository<T>().GetListAsync(condition);
            }).Wait();

            return records.AsQueryable();
        }

        public virtual IQueryable<T> GetAll()
        {
            IEnumerable<T> records = null;

            Task.Run(async () => {
                records = await new RepositoryFactory().CreateGenericRepository<T>().GetAllAsync();
            }).Wait();

            return records.AsQueryable();
        }
    }
}
