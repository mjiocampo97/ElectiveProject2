using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.RegisterService
{
    public interface IRegisterService
    {
        void AddUserAccount(UserAccount user);
    }
}
