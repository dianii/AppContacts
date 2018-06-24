using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContacts.ViewModel
{
    public class ContactDetailPageViewModel
    {
        #region Propiedades

        public Contact CurrentContacto { get; set; }
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }
        public Command ItemTappedCommand { get; set; }

        #endregion

        #region Constructor

        public ContactDetailPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.CurrentContacto = new Contact();
            SaveContactCommand = new Command(async () => await SaveContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());
        }

        #endregion

        #region Metodos

        private async Task SaveContact()
        {
            await App.DataBase.SaveItemAsync(CurrentContacto);
            await Navigation.PopToRootAsync();
        }

        private async Task DeleteContact()
        {
            if (CurrentContacto.Id !=0)
            {
                await App.DataBase.DeleteItemAsync(CurrentContacto);
            }            
            await Navigation.PopToRootAsync();
        }

        #endregion
    }
}
