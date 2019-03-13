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

      

        public List<Others> GetOthersUser(UserAccount othersUnderUser)
        {
            var others = _repository.Others.GetRange(c => c.UserId == othersUnderUser.AccountId);
            return others;
        }

        public void AddOthers(Others others)
        {
            _repository.Others.Add(others);
        }

        public void DeleteOthers(Others others)
        {
            _repository.Others.Delete(c => c.Id == others.Id);
        }

        public void UpdateOthers(Others oldOthers, Others newOthers)
        {
            _repository.Others.Update(c => c.Id == oldOthers.Id, newOthers);
        }


       
    }
}
