using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using AppContacts.Helpers;
using AppContacts.Model;
using Xamarin.Forms;
using AppContacts.View;

namespace AppContacts.ViewModel
{
    public class ContactsPageViewModel
    {
        #region Propiedades

        public Command AddContactCommand { get; set; }
        public INavigation Navigation { get; set; }
        public ObservableCollection<Grouping<string, Contact>> ContactsList { get; set; }

        #endregion

        #region Contructor

        public ContactsPageViewModel()
        {
            Task.Run(async () => ContactsList = await App.DataBase.GetAllGrouped()).Wait();
            AddContactCommand = new Command(async () => await GoToDetailContact());
        }



        #endregion

        #region Metodos

        private async Task GoToDetailContact()
        {
            await Navigation.PushAsync(new ContactDetailPage());
        }
        #endregion
    }
}
