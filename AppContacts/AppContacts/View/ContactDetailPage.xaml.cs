using AppContacts.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContacts.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailPage : ContentPage
	{
        public ContactDetailPageViewModel ViewModel { get; set; }
        public ContactDetailPage ()
		{
			InitializeComponent ();
            ViewModel = new ContactDetailPageViewModel(Navigation);
            this.BindingContext = ViewModel;
        }
	}
}