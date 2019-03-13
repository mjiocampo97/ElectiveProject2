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
	public partial class ExpensePage : TabbedPage
    {
        private ExpenseViewModel ExpenseViewModel;
        private ClothesViewModel ClothesViewModel = App.Locator.ClothesViewModel;
        private FoodViewModel FoodViewModel = App.Locator.FoodViewModel;
        private TransportationViewModel TransportationViewModel = App.Locator.TransportationViewModel;
        private OthersViewModel OthersViewModel = App.Locator.OthersViewModel;

        public ExpensePage()
        {
            InitializeComponent();
            ExpenseViewModel = App.Locator.ExpenseViewModel;
            var test1= new ExpensePage();
            Children.Add(test1);
        }

        public ExpensePage(UserAccount user)
        {
            InitializeComponent();
            ExpenseViewModel = App.Locator.ExpenseViewModel;
            ExpenseViewModel.User = user;
            BindingContext = ExpenseViewModel;
        }

        protected override void OnAppearing()
        {
         ExpenseViewModel.LoadClothes(ExpenseViewModel.User);

        }

    }
}