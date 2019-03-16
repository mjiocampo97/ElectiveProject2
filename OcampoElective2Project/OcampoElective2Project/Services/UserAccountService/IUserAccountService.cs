using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.UserAccountService
{
    public interface IUserAccountService
    {
        void UpdateUser(UserAccount oldUser,UserAccount newUser);
    }
}
