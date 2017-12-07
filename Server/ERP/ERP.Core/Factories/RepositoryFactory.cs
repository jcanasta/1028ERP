using ERP.Core.Abstracts;
using ERP.Core.DAL;
using ERP.Core.DAL.Entities;
using ERP.Core.Repositories;
using ERP.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Factories
{
    public class RepositoryFactory
    {
        protected DbContext db = null;

        public RepositoryFactory()
        {
            db = new ERPDataContext();
        }

        public RepositoryFactory(DbContext context)
        {
            db = context;
        }


        public IRepository<T> CreateRepository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>();
        }

        internal GenericRepository<T> CreateGenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(db);
        }

        public IOrderRepository CreateOrderRepository()
        {
            return new OrderRepository();
        }

    }
}
