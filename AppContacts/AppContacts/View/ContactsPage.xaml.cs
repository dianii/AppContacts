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
	public partial class ContacsPage : ContentPage
	{
		public ContacsPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ContactPageViewModel(Navigation);

        }
	}
}