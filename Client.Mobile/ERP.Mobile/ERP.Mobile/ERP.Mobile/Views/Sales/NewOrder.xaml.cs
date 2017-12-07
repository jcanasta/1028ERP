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
    public partial class NewOrder : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public NewOrder()
        {
            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

        }
    }
}
