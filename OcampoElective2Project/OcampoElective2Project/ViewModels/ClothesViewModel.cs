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

namespace OcampoElective2Project.ViewModels
{
    public class ClothesViewModel : OcampoElective2ProjectViewModel
    {
        private UserAccount _user;
        private Clothes _selectedClothes;

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
        public ObservableCollection<Clothes> ClothesList { get; set; }= new ObservableCollection<Clothes>();

        public Clothes SelectedClothes
        {
            get => _selectedClothes;
            set
            {
                _selectedClothes = value;
                RaisePropertyChanged(nameof(SelectedClothes);
            }
        }

        public ClothesViewModel(INavigationService navigationService, IClothesService clothesService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            ClothesService = clothesService;
    //       LoadClothes(User);

        }

        public void LoadClothes(UserAccount user)
        {
            ClothesList.Clear();
            foreach (var clothes in ClothesService.GetClothesUser(User))
            {
                ClothesList.Add(clothes);
            }
        }



        public ICommand AddClothesCommand => new RelayCommand(AddClothesProc);

        private void AddClothesProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddClothesPage, User, false);
            
        }
    }
}
