using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.IncomeService;
using OcampoElective2Project.Views;

namespace OcampoElective2Project.ViewModels
{
    public class AddIncomeViewModel : OcampoElective2ProjectViewModel
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

        public IIncomeService IncomeService{ get; set; }
        public Income IncomeToAdd { get; set; }

  
        

        public AddIncomeViewModel(INavigationService navigationService, IIncomeService incomeService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            IncomeService = incomeService;
            IncomeToAdd = new Income();
            
        }

        public ICommand SaveIncomeCommand => new RelayCommand(SaveIncomeProc);
        private void SaveIncomeProc()
        {
            IncomeToAdd.UserId = User.AccountId;
            if (App.Locator.IncomeViewModel.isUpdate == true)
            {
                
                IncomeToAdd.Id = App.Locator.IncomeViewModel.SelectedIncome.Id;
                IncomeService.UpdateIncome(App.Locator.IncomeViewModel.SelectedIncome, IncomeToAdd);
                

            }
            else
            {
                
                IncomeService.AddIncome(IncomeToAdd);
                User.Money += IncomeToAdd.IncomeMoney;
            }
            NavigationService.GoBack();
            App.Locator.ExpenseViewModel.isUpdate = false;
        }
    }
}
