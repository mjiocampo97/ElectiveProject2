using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.OthersService;
using OcampoElective2Project.Services.TransportationService;

namespace OcampoElective2Project.ViewModels
{
   public class ExpenseViewModel : OcampoElective2ProjectViewModel
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
        public IClothesService ClothesService { get; set; }
        public IFoodService FoodService { get; set; }
        public IOthersService OthersService { get; set; }
        public ITransportationService TransportationService { get; set; }
        public ExpenseViewModel(INavigationService navigationService, IClothesService clothesService, IFoodService foodService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            ClothesService = clothesService;
          
        }
    }
}
