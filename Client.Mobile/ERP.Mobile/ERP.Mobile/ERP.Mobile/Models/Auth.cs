using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Mobile.Models
{
    public class Auth
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
    }
}
