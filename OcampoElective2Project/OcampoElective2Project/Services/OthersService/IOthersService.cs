using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.OthersService
{
    public interface IOthersService
    {
        List<Others> GetOthersUser(UserAccount othersUnderUser);
        void AddOthers(Others Others);
        void DeleteOthers(Others Others);
        void UpdateOthers(Others oldOthers, Others newOthers);
    }
}
