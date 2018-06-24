using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using AppContacts.Data;
using AppContacts.Services;
using System.Diagnostics;

namespace AppContacts
{
	public partial class App : Application
	{
        private static ContactsDataBase dataBase;

        public static ContactsDataBase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    try
                    {
                        dataBase = new ContactsDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("contact.db3"));
                    }
                    catch (Exception ex )
                    {
                        Debug.WriteLine(ex.Message); 
                        throw;
                    }                    
                }
                return dataBase;
            }
        }

        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ContactsPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
