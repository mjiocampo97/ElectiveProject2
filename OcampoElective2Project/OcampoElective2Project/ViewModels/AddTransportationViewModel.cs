using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.TransportationService;

namespace OcampoElective2Project.ViewModels
{
    public class AddTransportationViewModel : OcampoElective2ProjectViewModel
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
        public Transportation TransportationToAdd { get; set; }
        public AddTransportationViewModel(INavigationService navigationService, ITransportationService transportationService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            TransportationService = transportationService;
            TransportationToAdd = new Transportation();

        }



        public ICommand SaveTransportationCommand => new RelayCommand(SaveTransportationProc);

        private void SaveTransportationProc()
        {
            TransportationToAdd.UserId = User.AccountId;
        
            if (App.Locator.ExpenseViewModel.isUpdate == true)
            {
                TransportationToAdd.Id = App.Locator.ExpenseViewModel.SelectedTransportation.Id;
               TransportationService.UpdateTransportation(App.Locator.ExpenseViewModel.SelectedTransportation, TransportationToAdd);
            
            }
            else
            {

               TransportationService.AddTransportation(TransportationToAdd);
               
            }
            NavigationService.GoBack();
            App.Locator.ClothesViewModel.isUpdate = false;
        }


       
    }
}
