using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWeek1.Models;

namespace XamarinWeek1.ViewModels
{
    class LoginPageViewModel
    {
        public ICommand LoginCommand { get; set; }
        public User User { get; set; }

         
        public LoginPageViewModel()
        {
            User = new User();

            LoginCommand = new Command(async() =>
            {
                ValidateLoginForm();
            }
            );
        }

        public async void  ValidateLoginForm()
        {

            if (String.IsNullOrEmpty(User.Username) || String.IsNullOrEmpty(User.Password))
                await App.Current.MainPage.DisplayAlert("Username and password fields are required", "Please check and try again.", "Accept");
            else
                await App.Current.MainPage.DisplayAlert("Login sucessful", $"Welcome {User.Username}!", "Ok");
        }
    }
}
