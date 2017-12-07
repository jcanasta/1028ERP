using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Mobile.Models
{
    public class Product : ModelBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        private  bool _isAddedToCart { get; set; }

        public bool IsAddedToCart
        {
            get { return _isAddedToCart; }
            set
            {
                _isAddedToCart = value;
                OnPropertyChanged();
            }
        }
    }
}
