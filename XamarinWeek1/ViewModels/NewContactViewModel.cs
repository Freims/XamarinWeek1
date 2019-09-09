using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWeek1.Models;

namespace XamarinWeek1.ViewModels
{
    public class NewContactViewModel
    {
        public Contact NewContact { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewContactCommand { get; set; }

        public NewContactViewModel()
        {

            AddNewContactCommand = new Command( () =>
            {
                MessagingCenter.Send<string, Contact>("MyApp", "NewContact", NewContact);
            });


        }


    }
}
