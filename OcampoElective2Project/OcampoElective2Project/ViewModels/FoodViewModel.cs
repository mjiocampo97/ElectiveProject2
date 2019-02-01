using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.CommandWpf;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class FoodViewModel : OcampoElective2ProjectViewModel
    {

        public RelayCommand AddFoodCommdand => new RelayCommand(AddFoodProc);

        private void AddFoodProc()
        {
            throw new NotImplementedException();
        }
    }
}
