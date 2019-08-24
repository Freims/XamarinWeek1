using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWeek1.ViewModels;

namespace XamarinWeek1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }

        private async void  LoginButtonClicked(object sender, EventArgs e)
        {
            string password = passwordInput.Text;
            string username = usernameInput.Text;

          if(String.IsNullOrEmpty(password) || String.IsNullOrEmpty(username))
                await DisplayAlert("Username and password fields are required", "Please check and try again.", "Accept");
          else
                await DisplayAlert("Login sucessful", $"Welcome {username}!", "Ok");

        }
    }
}
