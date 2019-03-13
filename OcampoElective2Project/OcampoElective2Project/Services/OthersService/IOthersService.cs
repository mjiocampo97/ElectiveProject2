using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.OthersService
{
    public interface IOthersService
    {
        List<Others> GetOthersUser(UserAccount foodUnderUser);
        void AddOthers(Others food);
        void DeleteOthers(Others food);
        void UpdateOthers(Others oldOthers, Food newOthers);
    }
}
