using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.OthersService;
using OcampoElective2Project.Services.TransportationService;

namespace OcampoElective2Project.ViewModels
{
    public class TransportationViewModel : OcampoElective2ProjectViewModel
    {
        private UserAccount _user;
        public UserAccount User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

        public ITransportationService TransportationService { get; set; }
        public TransportationViewModel(INavigationService navigationService, ITransportationService transportationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            TransportationService = transportationService;

        }
        public ICommand AddTransportationCommand => new RelayCommand(AddTransportationProc);

        private void AddTransportationProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddTransportationPage);
        }
    }
}
