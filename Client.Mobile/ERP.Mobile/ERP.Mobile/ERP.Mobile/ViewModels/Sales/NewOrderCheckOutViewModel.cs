using ERP.Mobile.Models;
using ERP.Mobile.Services;
using ERP.Mobile.Views.Sales;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ERP.Mobile.ViewModels.Sales
{
    public class NewOrderCheckOutViewModel : ViewModelBase
    {
        public SalesOrder SO { get; set; }
        public string CustomerName { get; set; } = Config.Instance.Auth.Name;

        public ICommand SaveCommand { get; private set; }

        public NewOrderCheckOutViewModel(SalesOrder so)
        {
            SaveCommand = new Command(async () => await Save());
            SO = so;
        }

        private async Task Save()
        {
            OrderService service = new OrderService();
            var res = await service.AddOrder(SO);

            if (!res)
            {
                await Application.Current.MainPage.DisplayAlert("Failed", "Unable to send orders.", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Success", "New order has been submitted.", "Ok");
                var master = Application.Current.MainPage as Views.Core.Layout;
                //set order info vm here
                master.SetDetailPage(new Menu { Id = 0, Title = "My Orders", TargetType = typeof(MyOrders), Context = typeof(MyOrdersViewModel) });
            }
        }
    }
}
