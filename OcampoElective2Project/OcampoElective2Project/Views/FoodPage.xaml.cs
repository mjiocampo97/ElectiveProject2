using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OcampoElective2Project.Models;
using OcampoElective2Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FoodPage : ContentPage
    {
        private ExpenseViewModel vm;
		public FoodPage ()
		{
			InitializeComponent ();
		    BindingContext = App.Locator.ExpenseViewModel;
        }

        public FoodPage(UserAccount user)
        {
            InitializeComponent();
            vm = App.Locator.ExpenseViewModel;
            vm.User = user;
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            //vm.LoadFood(vm.User);

        }
    }
}