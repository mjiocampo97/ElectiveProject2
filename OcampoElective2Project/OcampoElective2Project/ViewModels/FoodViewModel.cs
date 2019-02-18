using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;
using OcampoElective2Project.Services.FoodService;

namespace OcampoElective2Project.ViewModels
{
    public class FoodViewModel : OcampoElective2ProjectViewModel
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

        public IFoodService FoodService { get; set; }
        public ObservableCollection<Food> FoodList { get; set; } = new ObservableCollection<Food>();
        public FoodViewModel(INavigationService navigationService, IFoodService foodService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            FoodService = foodService;
          
        }

        public void LoadFood()
        {
            FoodList.Clear();
        }

        public ICommand AddFoodCommand => new RelayCommand(AddFoodProc);

        private void AddFoodProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddFoodPage);
        }


    }
}
