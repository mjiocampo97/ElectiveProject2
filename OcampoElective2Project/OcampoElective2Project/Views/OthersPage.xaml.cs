using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
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
	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        var currentPageKeyString = ServiceLocator.Current
	            .GetInstance<INavigationService>()
	            .CurrentPageKey;
	        Debug.WriteLine("Current page key: " + currentPageKeyString);
	    }

    }
}