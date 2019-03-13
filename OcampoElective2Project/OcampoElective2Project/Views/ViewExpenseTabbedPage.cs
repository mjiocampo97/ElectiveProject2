using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.ViewModels;
using Xamarin.Forms;

namespace OcampoElective2Project.Views
{
    public class ViewExpenseTabbedPage : TabbedPage
    {
        private ClothesViewModel ClothesViewModel = App.Locator.ClothesViewModel;
        private FoodViewModel FoodViewModel = App.Locator.FoodViewModel;
        private TransportationViewModel TransportationViewModel = App.Locator.TransportationViewModel;
        private OthersViewModel OthersViewModel = App.Locator.OthersViewModel;

        public ViewExpenseTabbedPage()
        {
            Title = "Expenses";
            Children.Add(new ClothesPage(ClothesViewModel.User));
            Children.Add(new FoodPage(FoodViewModel.User));
            Children.Add(new TransportationPage(TransportationViewModel.User));
            Children.Add(new OthersPage(OthersViewModel.User));

        }
    }
}
