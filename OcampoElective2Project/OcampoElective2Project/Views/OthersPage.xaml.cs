using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OthersPage : ContentPage
	{
		public OthersPage ()
		{
			InitializeComponent ();
		    BindingContext = App.Locator.OthersViewModel;
        }
	}
}