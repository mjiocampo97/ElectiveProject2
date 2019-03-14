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
    public partial class IncomePage : ContentPage
    {
        private IncomeViewModel IncomeViewModel;

        public IncomePage()
        {
            InitializeComponent();
            IncomeViewModel = App.Locator.IncomeViewModel;

        }

        public IncomePage(UserAccount user)
        {
            InitializeComponent();
            IncomeViewModel = App.Locator.IncomeViewModel;
            IncomeViewModel.User = user;
            BindingContext = IncomeViewModel;
        }
        protected override void OnAppearing()
        {
            IncomeViewModel.LoadIncome(IncomeViewModel.User);
           
        }
    }
}