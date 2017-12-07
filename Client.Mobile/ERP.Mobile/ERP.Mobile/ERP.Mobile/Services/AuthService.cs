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
    internal class AuthService
    {
        HttpClient client;

        public AuthService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task AuthenticateAync(string username, string password)
        {
            try
            {
                var json = JsonConvert.SerializeObject(new { Username = username, Password = password });
                var payload = new StringContent(json, Encoding.UTF8, "application/json");
                
                var res = await client.PostAsync($"{Config.Instance.APIUrl}/auth/signin", payload);

                var content = await res.Content.ReadAsStringAsync();

                if (res.IsSuccessStatusCode)
                {
                    Config.Instance.Auth = JsonConvert.DeserializeObject<Auth>(content);
                }
                else
                {
                    //can connect
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
