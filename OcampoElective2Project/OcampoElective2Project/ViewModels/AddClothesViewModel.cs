using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;

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
        public ICommand SaveClothesCommand => new RelayCommand(SaveClothesProc);

        private void SaveClothesProc()
        {
            throw new NotImplementedException();
        }
    }
}
