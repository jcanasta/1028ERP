using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; private set; }
        public UserType Type { get; set; }
        public string MasterDataID { get; set; }
        public byte[] Image { get; set; }

        public enum UserType
        {
            Employee,
            Customer
        }
    }
}
