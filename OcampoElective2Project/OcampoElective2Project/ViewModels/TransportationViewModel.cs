using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.CommandWpf;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class TransportationViewModel : OcampoElective2ProjectViewModel
    {
        public RelayCommand AddTransportationCommdand => new RelayCommand(AddTransportationProc);

        private void AddTransportationProc()
        {
            throw new NotImplementedException();
        }
    }
}
