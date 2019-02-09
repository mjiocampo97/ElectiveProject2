using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class AddOthersViewModel : OcampoElective2ProjectViewModel
    {
        public ICommand SaveOthersCommand => new RelayCommand(SaveOthersProc);

        private void SaveOthersProc()
        {
            throw new NotImplementedException();
        }
    }
}
