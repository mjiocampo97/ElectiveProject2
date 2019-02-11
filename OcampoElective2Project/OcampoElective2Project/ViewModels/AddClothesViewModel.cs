using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using OcampoElective2Project.Services;
using OcampoElective2Project.Services.ClothesService;

namespace OcampoElective2Project.ViewModels
{
    public class AddClothesViewModel : OcampoElective2ProjectViewModel
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
        public AddClothesViewModel(INavigationService navigationService, IClothesService clothesService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            ClothesService = clothesService;

        }

        public ICommand SaveClothesCommand => new RelayCommand(SaveClothesProc);

        private void SaveClothesProc()
        {
            throw new NotImplementedException();
        }

    }
}
