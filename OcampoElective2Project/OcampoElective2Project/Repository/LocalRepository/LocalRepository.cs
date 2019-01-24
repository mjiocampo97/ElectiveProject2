using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Repository.LocalRepository
{
    public class LocalRepository : IRepository

    {
        public IDataService<UserAccount> UserAccount { get; } = new LocalDataService<UserAccount>();
        public IDataService<Clothes> Clothes { get; } = new LocalDataService<Clothes>();
        public IDataService<Food> Food { get; }= new LocalDataService<Food>();
        public IDataService<Transportation> Transportation { get; } = new LocalDataService<Transportation>();
    }
}
