using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.CommandWpf;
using OcampoElective2Project.Helpers;

namespace OcampoElective2Project.ViewModels
{
    public class ClothesViewModel : OcampoElective2ProjectViewModel
    {
        public RelayCommand AddClothesCommdand => new RelayCommand(AddClothesProc);

        private void AddClothesProc()
        {
            throw new NotImplementedException();
        }
    }
}
