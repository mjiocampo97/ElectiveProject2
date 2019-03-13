using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OcampoElective2Project.Views
{
    public class ViewExpenseTabbedPage : TabbedPage
    {
        public ViewExpenseTabbedPage()
        {
            Title = "Expenses";
            Children.Add(new ClothesPage());
            Children.Add(new FoodPage());
            Children.Add(new TransportationPage());
            Children.Add(new OthersPage());

        }
    }
}
