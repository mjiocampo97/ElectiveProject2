using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class FoodViewModel : OcampoElective2ProjectViewModel
    {

        public ICommand AddFoodCommand => new RelayCommand(AddFoodProc);

        private void AddFoodProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddFoodPage);
        }
    }
}
