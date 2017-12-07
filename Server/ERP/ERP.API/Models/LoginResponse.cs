using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.API.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}