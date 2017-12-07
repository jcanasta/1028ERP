using ERP.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Mobile.Services
{
    public class ProductService
    {
        HttpClient client;

        private List<Product> TestProduct;


        public ProductService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var res = await client.GetAsync($"{Config.Instance.APIUrl}/product/get-all");
            var content = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
        }
    }
}
