using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.IncomeService;
using OcampoElective2Project.Services.UserAccountService;
using OcampoElective2Project.Views;
using SQLite;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
    public class AddIncomeViewModel : OcampoElective2ProjectViewModel
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");

        private UserAccount _user;
        public UserAccount User
        {
            get => _user;
            set { Set(ref _user, value); }
        }

        public IIncomeService IncomeService{ get; set; }
        public Income IncomeToAdd { get; set; }
   
        public IUserAccountService UserAccountService { get; set; }

        /// <summary>
      
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="incomeService"></param>


        public AddIncomeViewModel(INavigationService navigationService, IIncomeService incomeService, IUserAccountService userAccountService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            IncomeService = incomeService;
            IncomeToAdd = new Income();
            UserAccountService = userAccountService;
         

        }

        public ICommand SaveIncomeCommand => new RelayCommand(SaveIncomeProc);
        //public ICommand SaveIncomeCommand => new RelayCommand(async () => await SaveIncomeProc());
        private void SaveIncomeProc()
        {
            IncomeToAdd.UserId = User.AccountId;
            if (App.Locator.IncomeViewModel.isUpdate == true)
            {
                User.Money -= App.Locator.IncomeViewModel.SelectedIncome.IncomeMoney;
                User.Money += IncomeToAdd.IncomeMoney;
                IncomeToAdd.Id = App.Locator.IncomeViewModel.SelectedIncome.Id;
                IncomeService.UpdateIncome(App.Locator.IncomeViewModel.SelectedIncome, IncomeToAdd);
                

            }
            else
            {
              
                IncomeService.AddIncome(IncomeToAdd);
                User.Money += IncomeToAdd.IncomeMoney;          
               
                ;
               
                
            }

            if (User != null)
            {
               
                UserAccountService.UpdateUser(User, User);
              //  await Task.Delay(150);
                Task.Delay(150);
                NavigationService.GoBack();
            }
            else
            {
                //await Application.Current.MainPage.DisplayAlert("Error", "Please try again", "Cancel");
                Application.Current.MainPage.DisplayAlert("Error", "Please try again", "Cancel");
            }
            App.Locator.IncomeViewModel.isUpdate = false;
        }

        public void ChangeMoney(int userId, double money)
        {
            var user = new UserAccount() {AccountId = userId, Money = money};
           
        }
    }
}
