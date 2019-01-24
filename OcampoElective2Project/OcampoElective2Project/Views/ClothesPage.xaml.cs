using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using OcampoElective2Project;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClothesPage : ContentPage
	{
		public ClothesPage ()
		{
			InitializeComponent ();
		    this.BindingContext = App.Locator.ClothesViewModel;
		}
	}
}