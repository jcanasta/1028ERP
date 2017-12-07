using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.DAL.Entities
{
    public class SalesOrder : BaseEntity
    {
        public string TransactionNo { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        public List<OrderDetail> Details { get; set; }
    }
}
