using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Helpers;
using OcampoElective2Project.Models;
using Xamarin.Forms;

namespace OcampoElective2Project.ViewModels
{
    public class HomeViewModel : OcampoElective2ProjectViewModel
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

       
        
        

    }
}
