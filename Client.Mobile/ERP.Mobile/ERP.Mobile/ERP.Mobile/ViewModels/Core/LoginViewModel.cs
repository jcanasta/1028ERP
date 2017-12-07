using ERP.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ERP.Mobile.ViewModels.Core
{
    public class LoginViewModel : ViewModelBase
    {
        private AuthService service = new AuthService();

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }


        private async Task Login()
        {
            try
            {
                await service.AuthenticateAync(Username, Password);

                if (Config.Instance.Auth.Message == "Success")
                {
                    Application.Current.MainPage = new Views.Core.Layout();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Login Failed", Config.Instance.Auth.Message, "Ok");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
