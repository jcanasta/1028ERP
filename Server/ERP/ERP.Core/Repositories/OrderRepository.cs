using ERP.Core.Abstracts;
using ERP.Core.DAL.Entities;
using ERP.Core.Factories;
using ERP.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Repositories
{
    internal class OrderRepository : BaseRepository<SalesOrder>, IOrderRepository
    {
        public override void AddOrUpdate(SalesOrder model)
        {
            foreach (var det in model.Details)
            {
                det.Product = null;
            }
            model.Customer = null;
            model.TransactionNo = GenerateTransactionNo();
            base.AddOrUpdate(model);
        }

        private string GenerateTransactionNo()
        {
            var count = GetAll().Count() + 1;
            return $"SO{count.ToString("00000#")}";
        }
    }
}
