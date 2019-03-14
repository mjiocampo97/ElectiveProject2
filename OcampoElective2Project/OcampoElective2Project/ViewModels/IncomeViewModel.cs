using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.IncomeService;
using OcampoElective2Project.Services.OthersService;
using OcampoElective2Project.Services.TransportationService;

namespace OcampoElective2Project.ViewModels
{
    public class IncomeViewModel : OcampoElective2ProjectViewModel
    {



        private UserAccount _user;
        private Income _selectedIncome;

        public UserAccount User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

        public IIncomeService IncomeService { get; set; }
        public ObservableCollection<Income> IncomeList { get; set; } = new ObservableCollection<Income>();

        public Income SelectedIncome
        {
            get => _selectedIncome;
            set
            {
                _selectedIncome = value;
                RaisePropertyChanged(nameof(SelectedIncome));
            }
        }


        public IncomeViewModel(INavigationService navigationService, IIncomeService incomeService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            IncomeService = incomeService;
        }
       
    }
}
