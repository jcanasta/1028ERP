using ERP.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERP.Mobile.Views.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Layout : MasterDetailPage
    {
        public Layout()
        {
            InitializeComponent();

            //set the default detail here not in xaml
            SetDetailPage(new Menu() { Title = "Dashboard", TargetType = typeof(Dashboard.Dashboard) });
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        //transfer this to view model

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Menu;
            if (item == null)
                return;

            SetDetailPage(item);
        }

        public void SetDetailPage(Menu item)
        {
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            if (item.Context != null)
            {
                page.BindingContext = Activator.CreateInstance(item.Context);
            }

            var navPage = new NavigationPage(page);

            navPage.BarBackgroundColor = (Color)Application.Current.Resources["ThemeColor"];
            navPage.BarTextColor = (Color)Application.Current.Resources["ThemeFont"];

            Detail = navPage;
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }


        public void SetDetailPage(Page page)
        {

            var navPage = new NavigationPage(page);


            navPage.BarBackgroundColor = (Color)Application.Current.Resources["ThemeColor"];
            navPage.BarTextColor = (Color)Application.Current.Resources["ThemeFont"];

            //Detail.Navigation.PushAsync(navPage);

            Detail = navPage;
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}