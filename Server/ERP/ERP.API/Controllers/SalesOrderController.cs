using ERP.Core.DAL.Entities;
using ERP.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.API.Controllers
{
    [RoutePrefix("api/order")]
    public class SalesOrderController : ApiController
    {
        [HttpGet]
        [Route("get-all")]
        public IEnumerable<SalesOrder> GetOrders()
        {
            var repo = new RepositoryFactory().CreateOrderRepository();
            return repo.GetAll();
        }

        [HttpGet]
        [Route("get-order")]
        public IEnumerable<SalesOrder> GetMyOrders(string transactionNo)
        {
            var repo = new RepositoryFactory().CreateOrderRepository();
            return repo.Get(x => x.TransactionNo == transactionNo);
        }

        [HttpGet]
        [Route("my-orders")]
        public IEnumerable<SalesOrder> GetMyOrders(int customerID)
        {
            var repo = new RepositoryFactory().CreateOrderRepository();
            return repo.Get(x => x.CustomerID == customerID);
        }

        [HttpPost]
        [Route("add")]
        public void AddOrder([FromBody] SalesOrder so)
        {
            try
            {
                so.Status = "Pending";
                var repo = new RepositoryFactory().CreateOrderRepository();
                repo.AddOrUpdate(so);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
