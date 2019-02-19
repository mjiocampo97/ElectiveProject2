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
using OcampoElective2Project.Services.FoodService;
using OcampoElective2Project.Services.OthersService;

namespace OcampoElective2Project.ViewModels
{
    public class OthersViewModel : OcampoElective2ProjectViewModel

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

        public IOthersService OthersService { get; set; }
        public ObservableCollection<Others> OthersList { get; set; } = new ObservableCollection<Others>();
        public OthersViewModel(INavigationService navigationService, IOthersService othersService)
        {
            if (navigationService == null) throw new ArgumentNullException("navigationService");
            NavigationService = (NavigationService)navigationService;
            OthersService = othersService;

        }

        public void LoadOthers()
        {
            OthersList.Clear();
        }

        public ICommand AddOthersCommand => new RelayCommand(AddOthersProc);

        private void AddOthersProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddOthersPage,User,false);
        }

    }
}
