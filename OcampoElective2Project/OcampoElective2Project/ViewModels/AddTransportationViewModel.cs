using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.TransportationService;
using OcampoElective2Project.Services.UserAccountService;

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
        public IUserAccountService UserAccountService { get; set; }
        public Transportation TransportationToAdd { get; set; }
        public AddTransportationViewModel(INavigationService navigationService, ITransportationService transportationService, IUserAccountService userAccountService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            TransportationService = transportationService;
            TransportationToAdd = new Transportation();
            UserAccountService = userAccountService;
        }



        public ICommand SaveTransportationCommand => new RelayCommand(async() => await SaveTransportationProc());
        //public ICommand SaveTransportationCommand => new RelayCommand( async () => SaveTransportationProc());
        //private task async  SaveTransportationProc()
        //private async task
        private  async Task SaveTransportationProc()
        {
            TransportationToAdd.UserId = User.AccountId;
           
            if (App.Locator.ExpenseViewModel.isUpdate == true)
            {
                User.Money += App.Locator.ExpenseViewModel.SelectedTransportation.Price;
                User.Money -= TransportationToAdd.Price;
                TransportationToAdd.Id = App.Locator.ExpenseViewModel.SelectedTransportation.Id;
               TransportationService.UpdateTransportation(App.Locator.ExpenseViewModel.SelectedTransportation, TransportationToAdd);
            
            }
            else
            {

               TransportationService.AddTransportation(TransportationToAdd);
               User.Money -= TransportationToAdd.Price;
            
            }
            NavigationService.GoBack();
         //  UpdateIncome();
            UserAccountService.UpdateUser(User,User);
            App.Locator.ExpenseViewModel.isUpdate = false;
        }

        private void UpdateIncome()
        {
        //    UserAccountService.UpdateUser(User);
        }

       
    }
}
