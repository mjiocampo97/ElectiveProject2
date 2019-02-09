using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OcampoElective2Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		    BindingContext = App.Locator.MenuViewModel;
        }
	    public MenuPage(UserAccount user)
	    {
	        InitializeComponent();
	        var vm = App.Locator.MenuViewModel;
	        vm.User = user;
	        BindingContext = vm;

	    }

    }
}