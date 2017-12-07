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
    public class MyOrdersViewModel : ViewModelBase
    {
        OrderService service = new OrderService();

        private ObservableCollection<SalesOrder> _myOrders = null;

        public ObservableCollection<SalesOrder> MyOrders
        {
            get {
                return _myOrders;
            }
            set
            {
                _myOrders = value;
                OnPropertyChanged();
            }
        }

        public ICommand ViewOrderCommand { get; private set; }
        public ICommand NewOrderCommand { get; private set; }

        public MyOrdersViewModel()
        {
            ViewOrderCommand = new Command(cmd => ViewOrder(cmd as SalesOrder));
            NewOrderCommand = new Command(() => NewOrder());
            LoadOrders();
        }

        private async Task LoadOrders()
        {
            MyOrders = new ObservableCollection<SalesOrder>(await service.GetOrders());
        }

        private void ViewOrder(SalesOrder so)
        {
            var master = Application.Current.MainPage as Views.Core.Layout;
            //set order info vm here
            master.SetDetailPage(new OrderInfo() { Title = "Order Info", BindingContext = new OrderInfoViewModel(so)});
        }

        private void NewOrder()
        {
            var master = Application.Current.MainPage as Views.Core.Layout;
            //set order info vm here
            master.SetDetailPage(new NewOrder() { Title = "New Order", BindingContext = new NewOrderViewModel()});
        }
    }
}
