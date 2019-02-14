using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using OcampoElective2Project;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Models;
using OcampoElective2Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClothesPage : ContentPage
    {
        private ClothesViewModel vm;
		public ClothesPage ()
		{
			InitializeComponent ();
		    vm = App.Locator.ClothesViewModel;

		}
	

	    public ClothesPage(UserAccount user)
	    {
	        InitializeComponent();
            vm = App.Locator.ClothesViewModel;
            vm.User = user;
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
          vm.LoadClothes(vm.User);

        }
    }
}