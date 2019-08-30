using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWeek1.Models;

namespace XamarinWeek1.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }
        public User User { get; set; }
        public string ValidationMessage { get; set; }
        public bool ValidationLabelVisible { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

         
        public LoginPageViewModel()
        {
            User = new User();
            ValidationLabelVisible = false;
            
            LoginCommand = new Command(async() =>
            {
                ValidateLoginForm();
            }
            );

        }
        public async void  ValidateLoginForm()
        {
        
            ValidationLabelVisible = false;
            if (String.IsNullOrEmpty(User.Username) || String.IsNullOrEmpty(User.Password))
            {
                ValidationMessage = "Both fields can't be left blank. Please check.";
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Login sucessful", $"Welcome {User.Username}!", "Ok");
            }

        }

        
    }
}
