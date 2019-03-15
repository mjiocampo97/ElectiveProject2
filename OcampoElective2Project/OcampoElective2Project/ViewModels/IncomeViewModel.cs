using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.IncomeService;
using OcampoElective2Project.Services.OthersService;
using OcampoElective2Project.Services.TransportationService;
using OcampoElective2Project.Services.UserAccountService;
using OcampoElective2Project.Views;
using Xamarin.Forms;

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
        public bool isUpdate { get; set; }

        public IIncomeService IncomeService { get; set; }
        public IUserAccountService UserAccountService { get; set; }
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


        public IncomeViewModel(INavigationService navigationService, IIncomeService incomeService, IUserAccountService userAccountService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            IncomeService = incomeService;
            UserAccountService = userAccountService;
        }



        public void LoadIncome(UserAccount user)
        {
            IncomeList.Clear();
            foreach (var  income in IncomeService.GetIncomeUser(User))
                 {
                        IncomeList.Add(income);
                 }
        }

        public ICommand AddIncomeCommand=> new RelayCommand(AddIncomeProc);

        private void AddIncomeProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddIncomePage, User, false);
        }

        public ICommand DeleteIncomeCommand => new RelayCommand(DeleteIncomeProc);

        private void DeleteIncomeProc()
        {
            if (SelectedIncome != null)
            {

                IncomeService.DeleteIncome(SelectedIncome);
                User.Money -= SelectedIncome.IncomeMoney;
                UserAccountService.UpdateUser(User);
                RefreshIncome();
            }
            else
            {

                Application.Current.MainPage.DisplayAlert("Error",
                    "Please Select an Income that you want to be deleted", "Cancel");

            }

        }

        public ICommand UpdateIncomeCommand => new RelayCommand(UpdateIncomeProc);

        private void UpdateIncomeProc()
        {
            if (SelectedIncome != null)
            {
                isUpdate = true;
                NavigationService.NavigateTo(ViewModelLocator.AddIncomePage,User,false);
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please Select an Income that you want to be updated", "Cancel");
            }

        }

        public void RefreshIncome()
        {
            IncomeList.Clear();
            foreach (var income in IncomeService.GetIncomeUser(User))
            {
                IncomeList.Add(income);
            }
        }
    }


//    public ICommand DeleteClothesCommand => new RelayCommand(DeleteClothesProc);

//    public void DeleteClothesProc()
//    {
//    if (SelectedClothes != null)
//    {
//    ClothesService.DeleteClothes(SelectedClothes);
//    Refresh();
//    }
//    else
//    {
//    Application.Current.MainPage.DisplayAlert("Error", "Please Select a clothe that you want to be deleted", "Cancel");
//    }

//}

//public void Refresh()
//{
//ClothesList.Clear();
//foreach (var clothes in ClothesService.GetClothesUser(User))
//{
//    ClothesList.Add(clothes);
//}
//}


//public ICommand AddClothesCommand => new RelayCommand(AddClothesProc);

//private void AddClothesProc()
//{
//NavigationService.NavigateTo(ViewModelLocator.AddClothesPage, User, false);

//}

//public bool isUpdate { get; set; }
//public ICommand UpdateClothesCommand => new RelayCommand(UpdateClothesProc);

//private void UpdateClothesProc()
//{
//if (SelectedClothes != null)
//{
//isUpdate = true;
//NavigationService.NavigateTo(ViewModelLocator.AddClothesPage, User, false);

//}
//else
//{
//Application.Current.MainPage.DisplayAlert("Error", "Please Select a clothe that you want to be updated", "Cancel");
//}

//return;

}
