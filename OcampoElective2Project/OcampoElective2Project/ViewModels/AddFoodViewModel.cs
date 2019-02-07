using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class AddFoodViewModel : OcampoElective2ProjectViewModel
    {
        public ICommand SaveFoodCommand => new RelayCommand(SaveFoodProc);

        private void SaveFoodProc()
        {
            throw new NotImplementedException();
        }
    }
}
