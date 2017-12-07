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
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var repo = new RepositoryFactory().CreateRepository<Product>();
            return repo.GetAll();
        }
    }
}
