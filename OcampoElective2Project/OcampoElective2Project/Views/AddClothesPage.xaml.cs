﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OcampoElective2Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClothesPage : ContentPage
	{
		public AddClothesPage ()
		{
			InitializeComponent ();
            BindingContext = App.Locator.AddClothesViewModel;
        }
	}
}