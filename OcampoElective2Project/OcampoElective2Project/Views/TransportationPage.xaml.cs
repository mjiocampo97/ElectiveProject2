using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Models;
using OcampoElective2Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransportationPage : ContentPage
    {

        public ExpenseViewModel vm;
		public TransportationPage ()
		{
			InitializeComponent ();
		    BindingContext = App.Locator.ExpenseViewModel;
        }
	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        var currentPageKeyString = ServiceLocator.Current
	            .GetInstance<INavigationService>()
	            .CurrentPageKey;
	        Debug.WriteLine("Current page key: " + currentPageKeyString);
	    }
        public TransportationPage(UserAccount user)
        {
            InitializeComponent();
            vm = App.Locator.ExpenseViewModel;
            vm.User = user;
            BindingContext = vm;
        }
    }
}