using ERP.Mobile.Models;
using ERP.Mobile.ViewModels.Sales;
using ERP.Mobile.Views.Accounts;
using ERP.Mobile.Views.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ERP.Mobile.ViewModels.Core
{
    public class LayoutMasterViewModel : ViewModelBase
    {
        public ObservableCollection<Menu> MenuItems { get; set; }
        public string DisplayName { get; set; } = Config.Instance.Auth.Name;

        public LayoutMasterViewModel()
        {
            //temporary menus

            MenuItems = new ObservableCollection<Menu>(new[] {
                //new Menu { Id = 0, Title = "My Account",  TargetType= typeof(MyAccount) },
                new Menu { Id = 0, Title = "My Orders",  TargetType= typeof(MyOrders), Context = typeof(MyOrdersViewModel) },
            });
        }
    }
}
