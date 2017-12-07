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
    public class NewOrderViewModel : ViewModelBase
    {
        ProductService service = new ProductService();
        List<OrderDetail> cart = new List<OrderDetail>();

        public ObservableCollection<Product> Products { get; set; }
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand CheckoutCommand { get; private set; }

        public NewOrderViewModel()
        {
            AddItemCommand = new Command(cmd => AddItem(cmd as Product));
            RemoveItemCommand = new Command(cmd => RemoveItem(cmd as Product));
            CheckoutCommand = new Command(() => CheckOut());
            Task.Run(async () =>
            {
                Products = new ObservableCollection<Product>(await service.GetProducts());
            }).Wait();
        }

        private void AddItem(Product product)
        {
            if (cart.FirstOrDefault(x => x.ProductID == product.ID) != null)
            {
                cart.FirstOrDefault(x => x.ProductID == product.ID).Qty++;
                return;
            }

            Products.FirstOrDefault(x => x.ID == product.ID).IsAddedToCart = true;
            cart.Add(new OrderDetail() { ProductID = product.ID, Product = product, UnitPrice = product.UnitPrice, Qty = 1 });
        }

        private void RemoveItem(Product product)
        {
            Products.FirstOrDefault(x => x.ID == product.ID).IsAddedToCart = false;
            cart.Remove(cart.FirstOrDefault(x => x.ProductID == product.ID));
        }

        private void CheckOut()
        {
            var master = Application.Current.MainPage as Views.Core.Layout;
            //set order info vm here
            SalesOrder so = new SalesOrder() { Date = DateTime.Now, CustomerID = Config.Instance.Auth.UserID.ToString() };

            foreach (var order in cart)
            {
                so.AddDetail(order);
            }
            
            master.SetDetailPage(new NewOrderCheckOut() { Title = "Check Out", BindingContext = new NewOrderCheckOutViewModel(so) });
        }
    }
}