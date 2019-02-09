using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class AddTransportationViewModel : OcampoElective2ProjectViewModel
    {
        public ICommand SaveTransportationCommand => new RelayCommand(SaveTransportationProc);

        private void SaveTransportationProc()
        {
            throw new NotImplementedException();
        }
    }
}
