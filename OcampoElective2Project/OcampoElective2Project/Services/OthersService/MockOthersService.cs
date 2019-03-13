using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;

namespace OcampoElective2Project.Services.OthersService
{
    public class MockOthersService : IOthersService

    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");

        private IRepository _repository;
        public MockOthersService()
        {
            _repository = new LocalRepository();
        }

        public List<Others> GetOthersUser(UserAccount foodUnderUser)
        {
            throw new NotImplementedException();
        }

        public void AddOthers(Others food)
        {
            throw new NotImplementedException();
        }

        public void DeleteOthers(Others food)
        {
            throw new NotImplementedException();
        }

        public void UpdateOthers(Others oldOthers, Food newOthers)
        {
            throw new NotImplementedException();
        }
    }
}
