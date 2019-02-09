using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class OthersViewModel : OcampoElective2ProjectViewModel

    {
        public ICommand AddOthersCommand => new RelayCommand(AddOthersProc);

        private void AddOthersProc()
        {
            NavigationService.NavigateTo(ViewModelLocator.AddOthersPage);
        }

    }
}
