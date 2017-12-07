using ERP.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Mobile.ViewModels.Sales
{
    public class OrderInfoViewModel : ViewModelBase
    {
        public SalesOrder SO { get; set; }
        public string CustomerName { get; set; } = Config.Instance.Auth.Name;

        public OrderInfoViewModel(SalesOrder so)
        {
            SO = so;
        }
    }
}
