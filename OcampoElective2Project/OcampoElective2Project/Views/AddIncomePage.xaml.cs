using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddIncomePage : ContentPage
	{
		public AddIncomePage ()
		{
			InitializeComponent ();
            BindingContext = App.Locator.AddIncomeViewModel;
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }


        protected override void OnAppearing()
        {

            base.OnAppearing();
            var currentPageKeyString = ServiceLocator.Current
                .GetInstance<INavigationService>()
                .CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);


            if (App.Locator.IncomeViewModel.isUpdate == true)
            {
                NamePrice.Text = App.Locator.IncomeViewModel.SelectedIncome.IncomeMoney.ToString(CultureInfo.InvariantCulture);
                NameEntry.Text = App.Locator.IncomeViewModel.SelectedIncome.Name;

            }
            else
            {
                NamePrice.Text = "";
                NameEntry.Text = "";
            }

        }


        public AddIncomePage(UserAccount user)
        {
            InitializeComponent();

            App.Locator.AddIncomeViewModel.User = user;
            this.BindingContext = App.Locator.AddIncomeViewModel;
        }
        protected override bool OnBackButtonPressed()
        {
            App.Locator.IncomeViewModel.isUpdate = false;
            return base.OnBackButtonPressed();
        }
        //public AddFoodPage()
        //{
        //    InitializeComponent();
        //    BindingContext = App.Locator.AddFoodViewModel;
        //}
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var currentPageKeyString = ServiceLocator.Current
        //        .GetInstance<INavigationService>()
        //        .CurrentPageKey;
        //    Debug.WriteLine("Current page key: " + currentPageKeyString);
        //}
        //public AddFoodPage(UserAccount user)
        //{
        //    InitializeComponent();

        //    App.Locator.AddFoodViewModel.User = user;
        //    this.BindingContext = App.Locator.AddFoodViewModel;
        //}
    }
}