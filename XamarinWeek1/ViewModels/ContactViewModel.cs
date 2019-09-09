using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinWeek1.Models;
using XamarinWeek1.Views;

namespace XamarinWeek1.ViewModels
{
    public class ContactViewModel
    {
        Contact contact;
        public Contact SelectedContact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;

                if (contact != null)
                    OnSelectItem(contact);

            }
        }

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public Command<Contact> DeleteElementCommand { get; }
        public Command<Contact> MoreCommand { get; }

        public ICommand AddContactCommand { get; set; }

        public ContactViewModel()
        {
            Contact myContact = new Contact();
            myContact.Name = "Pablo";
            myContact.PhoneNumber = "+18095674389";

            Contacts.Add(myContact);

            DeleteElementCommand = new Command<Contact>(async (param) =>
            {
                //Action sheet sample
                var result = await App.Current.MainPage.DisplayAlert("Delete contact", "Are you sure you want to delete this contact?", "Yes", "Cancel");
                //var result = await App.Current.MainPage.DisplayActionSheet("Menu", "Cancel", "Destruction", "Button1", "Button2");
                if(result == true)
                {
                    Contacts.Remove(param);
                }
            });

            MoreCommand = new Command<Contact>(async (param) =>
            {
               
                var result = await App.Current.MainPage.DisplayActionSheet("Menu", "Cancel","", $"Call {param.PhoneNumber}", "Edit");
                if(result == $"Call {param.PhoneNumber}")
                {
                    PhoneDialer.Open(param.PhoneNumber);
                }
            });

            AddContactCommand = new Command(async()=>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NewContactPage());
            });


            //Messaging Center sample
            MessagingCenter.Subscribe<string, Contact>(this, "TESTID", ((sender, param) =>
            {
                MessagingCenter.Unsubscribe<App, string>(this, "TESTID");
            }));
            
        }

        void OnSelectItem(Contact contact)
        {
          
        }
    }

}

