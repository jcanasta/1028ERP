using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERP.Mobile.Views.Sales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderCheckOut : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public NewOrderCheckOut()
        {
            InitializeComponent();
        }
    }
}
