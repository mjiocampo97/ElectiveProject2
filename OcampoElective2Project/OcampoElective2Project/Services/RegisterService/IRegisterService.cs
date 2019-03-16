using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.RegisterService
{
    public interface IRegisterService
    {
        List<UserAccount> GetAllUsers();
        void AddUserAccount(UserAccount user);
        UserAccount Check(string username);
    }
}
