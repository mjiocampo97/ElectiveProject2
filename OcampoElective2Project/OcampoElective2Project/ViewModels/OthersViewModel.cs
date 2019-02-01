using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Command;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class OthersViewModel : OcampoElective2ProjectViewModel

    {
        public RelayCommand AddOthersCommdand => new RelayCommand(AddOthersProc);

        private void AddOthersProc()
        {
            throw new NotImplementedException();
        }

    }
}
