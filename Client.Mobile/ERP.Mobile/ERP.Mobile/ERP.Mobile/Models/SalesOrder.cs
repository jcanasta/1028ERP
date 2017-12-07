using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Mobile.Models
{
    public class SalesOrder : ModelBase
    {
        private decimal _total { get; set; }
        private List<OrderDetail> details { get; set; } = new List<OrderDetail>();

        public string TransactionNo { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string CustomerID { get; set; }

        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<OrderDetail> Details
        {
            get { return details; }
            set
            {
                OnPropertyChanged();
            }
        }

        public void AddDetail(OrderDetail order)
        {
            order.SetHeaderCalculationAction(CalculateTotal);
            details.Add(order);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var total = 0M;
            foreach (var order in Details)
            {
                total += order.Amount;
            }

            Total = total;
        }
    }
}
