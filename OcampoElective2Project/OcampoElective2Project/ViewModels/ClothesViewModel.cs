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
using Xamarin.Forms;

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
                RaisePropertyChanged(nameof(SelectedClothes));
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

        public ICommand DeleteClothesCommand => new RelayCommand(DeleteClothesProc);

        public void DeleteClothesProc()
        {
            ClothesService.DeleteClothes(SelectedClothes);
            Refresh();
            
        }

        public void Refresh()
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

        public bool isUpdate { get; set; }
        public ICommand UpdateClothesCommand => new RelayCommand(UpdateClothesProc);

        private void UpdateClothesProc()
        {
            if(SelectedClothes !=null)
            { 
            isUpdate = true;
            NavigationService.NavigateTo(ViewModelLocator.AddClothesPage, User, false);

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please Select a clothe that you want to be updated", "Cancel");
            }
                
            return;

        }
    }
}
