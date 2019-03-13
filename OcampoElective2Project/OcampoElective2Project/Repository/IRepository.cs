using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Repository
{
    public interface IRepository
    {
        IDataService<UserAccount> UserAccount { get; }
        IDataService<Clothes> Clothes { get; }
        IDataService<Food> Food { get; }
        IDataService<Transportation> Transportation { get; }
        IDataService<Others> Others { get; }
    }
}
