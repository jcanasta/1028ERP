using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string Area { get; set; }
        public string Cluster { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
    }
}
