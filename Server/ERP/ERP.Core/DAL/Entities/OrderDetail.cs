using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.DAL.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        
        [ForeignKey("OrderID")]
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
