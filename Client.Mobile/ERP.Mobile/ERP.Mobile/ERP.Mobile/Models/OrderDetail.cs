using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ERP.Mobile.Models
{
    public class OrderDetail : ModelBase
    {
        private double _qty { get; set; }
        private decimal _amount { get; set; }
        private Action _calculateHeaderTotal = null;


        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }

        public ICommand IncreaseQtyCommand { get; private set; }
        public ICommand DecreaseQtyCommand { get; private set; }
        public Product Product { get; set; }

        public OrderDetail()
        {
            IncreaseQtyCommand = new Command(() => IncreaseQty());
            DecreaseQtyCommand = new Command(() => DecreaseQty());
        }

        public double Qty
        {
            get
            {
                return _qty;
            }
            set
            {
                _qty = value;
                Amount = (decimal)Qty * UnitPrice;
                _calculateHeaderTotal?.Invoke();
                OnPropertyChanged();
            }
        }

        public decimal Amount
        {
            get { return _amount; }
            set {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public void SetHeaderCalculationAction(Action calcAction)
        {
            _calculateHeaderTotal = calcAction;
        }

        private void IncreaseQty()
        {
            Qty++;
        }

        private void DecreaseQty()
        {
            Qty--;
        }
    }
}
