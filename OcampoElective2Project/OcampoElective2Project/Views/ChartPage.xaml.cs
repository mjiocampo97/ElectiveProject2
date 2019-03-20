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
	public partial class ChartPage : ContentPage
    {
        private ExpenseViewModel ExpenseViewModel;
        public ChartPage ()
		{
			InitializeComponent();
            ExpenseViewModel = App.Locator.ExpenseViewModel;
        }

        public ChartPage(UserAccount user)
        {
            InitializeComponent();
            ExpenseViewModel = App.Locator.ExpenseViewModel;
            ExpenseViewModel.User = user;
            BindingContext = ExpenseViewModel;
        }
    }
}