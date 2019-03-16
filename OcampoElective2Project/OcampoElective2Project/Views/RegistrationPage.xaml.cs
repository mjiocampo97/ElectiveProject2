using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
    {
        private RegistrationViewModel vm;
		public RegistrationPage ()
		{
			InitializeComponent ();
		    BindingContext = App.Locator.RegistrationViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var currentPageKeyString = ServiceLocator.Current
                .GetInstance<INavigationService>()
                .CurrentPageKey;
            Debug.WriteLine("Current page key: " + currentPageKeyString);


            UserName.Text = "";
            Password.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            EmailAddress.Text = "";

        }

        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            vm = App.Locator.RegistrationViewModel;
            vm.UserAccountToAdd.BirthDate = DateTime.Date.ToShortDateString();
        }
    }
}