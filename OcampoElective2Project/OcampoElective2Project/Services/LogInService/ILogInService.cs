using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.LogInService
{
    public interface ILogInService
    {
        UserAccount Check(string username, string password);
    }
}
