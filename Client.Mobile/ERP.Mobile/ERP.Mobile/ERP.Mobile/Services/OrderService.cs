using ERP.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Mobile.Services
{
    public class OrderService
    {
        HttpClient client;

        public OrderService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        //public ObservableCollection<Order> TestOrders;

        //public OrderService()
        //{
        //    TestOrders = new ObservableCollection<Order>(new[]
        //    {
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0001", Total = 1000, Status = "Approved" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0002", Total = 2000, Status = "Approved" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0003", Total = 3000, Status = "Cancelled" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0004", Total = 4000, Status = "Pending" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0005", Total = 5000, Status = "Pending" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0006", Total = 1000, Status = "Approved" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0007", Total = 2000, Status = "Approved" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0008", Total = 4000, Status = "Pending" },
        //        new Order(){ Date = DateTime.Now, OrderID = "SO0009", Total = 5000, Status = "Pending" },
        //    });
        //}

        public async Task<IEnumerable<SalesOrder>> GetOrders()
        {
            var res = await client.GetAsync($"{Config.Instance.APIUrl}/order/my-orders?customerID=" + Config.Instance.Auth.UserID);
            var content = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<SalesOrder>>(content);
        }

        public async Task<bool> AddOrder(SalesOrder so)
        {
            try
            {
                
                var json = JsonConvert.SerializeObject(so);
                var payload = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await client.PostAsync($"{Config.Instance.APIUrl}/order/add", payload);
                var content = await res.Content.ReadAsStringAsync();

                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //throw ex;

                return false;
            }
        }

    }
}
