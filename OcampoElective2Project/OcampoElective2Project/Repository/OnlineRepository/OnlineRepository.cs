using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Repository.OnlineRepository
{
    public class OnlineRepository : IRepository
    {
        public IDataService<UserAccount> UserAccount { get; } = new OnlineDataService<UserAccount>();
        public IDataService<Clothes> Clothes { get; } = new OnlineDataService<Clothes>();
        public IDataService<Food> Food { get; } = new OnlineDataService<Food>();
        public IDataService<Transportation> Transportation { get; } = new OnlineDataService<Transportation>();
        public  IDataService<Others> Others { get; } = new OnlineDataService<Others>();
        public IDataService<Income> Income { get; }
    }
}
