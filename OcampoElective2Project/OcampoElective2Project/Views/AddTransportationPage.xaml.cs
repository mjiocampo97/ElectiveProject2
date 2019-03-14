using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTransportationPage : ContentPage
	{
		public AddTransportationPage ()
		{
			InitializeComponent ();
            BindingContext = App.Locator.AddTransportationViewModel;
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
            var currentPageKeyString = ServiceLocator.Current
                .GetInstance<INavigationService>()
                .CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);



            if (App.Locator.ExpenseViewModel.isUpdate == true)
            {
                NamePrice.Text = App.Locator.ExpenseViewModel.SelectedTransportation.Price.ToString(CultureInfo.InvariantCulture);
                NameEntry.Text = App.Locator.ExpenseViewModel.SelectedTransportation.Name;

            }
            else
            {
                NamePrice.Text = "";
                NameEntry.Text = "";
            }

        }
        public AddTransportationPage(UserAccount user)
	    {
	        InitializeComponent();

	        App.Locator.AddTransportationViewModel.User = user;
	        this.BindingContext = App.Locator.AddTransportationViewModel;
	    }
        protected override bool OnBackButtonPressed()
        {
            App.Locator.ExpenseViewModel.isUpdate = false;
            return base.OnBackButtonPressed();
        }
    }
}