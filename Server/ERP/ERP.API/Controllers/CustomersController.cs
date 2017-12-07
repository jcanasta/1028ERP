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
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            var repo = new RepositoryFactory().CreateRepository<Customer>();
            return repo.GetAll();
        }
    }
}
