using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class TransportationViewModel : OcampoElective2ProjectViewModel
    {
        public ICommand AddTransportationCommand => new RelayCommand(AddTransportationProc);

        private void AddTransportationProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddTransportationPage);
        }
    }
}
