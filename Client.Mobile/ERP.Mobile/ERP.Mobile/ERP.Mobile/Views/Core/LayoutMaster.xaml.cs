using ERP.Mobile.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERP.Mobile.Views.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LayoutMaster : ContentPage
    {
        public ListView ListView;

        public LayoutMaster()
        {
            InitializeComponent();

            BindingContext = new LayoutMasterViewModel();
            ListView = MenuItemsListView;
        }

        //class LayoutMasterViewModel : INotifyPropertyChanged
        //{
        //    public ObservableCollection<LayoutMenuItem> MenuItems { get; set; }

        //    public LayoutMasterViewModel()
        //    {
        //        MenuItems = new ObservableCollection<LayoutMenuItem>(new[]
        //        {
        //            new LayoutMenuItem { Id = 0, Title = "Page 1" },
        //            new LayoutMenuItem { Id = 1, Title = "Page 2" },
        //            new LayoutMenuItem { Id = 2, Title = "Page 3" },
        //            new LayoutMenuItem { Id = 3, Title = "Page 4" },
        //            new LayoutMenuItem { Id = 4, Title = "Page 5" },
        //        });
        //    }

        //    #region INotifyPropertyChanged Implementation
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //    {
        //        if (PropertyChanged == null)
        //            return;

        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //    #endregion
        //}
    }
}