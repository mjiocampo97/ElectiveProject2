using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;

namespace OcampoElective2Project.Services.RegisterService
{


    public class MockRegisterService : IRegisterService
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");

        private IRepository _repository;
        public ObservableCollection<UserAccount> Users { get; } = new ObservableCollection<UserAccount>();
        public MockRegisterService()
        {
            _repository = new LocalRepository();
           
        }


        public List<UserAccount> GetAllUsers()
        {

            var others = _repository.UserAccount.GetAll();
            return others;
        }

        public void AddUserAccount(UserAccount user)
        {
            _repository.UserAccount.Add(user);
        }

        public UserAccount Check(string username)
        {
            
            var user = _repository.UserAccount.GetAll().FirstOrDefault(c => c.Username == username);
           
            return user;
        }

        public void CheckUserNameList()
        {
            foreach (var VARIABLE in _repository.UserAccount.GetAll())
            {
                Users.Add(VARIABLE);
            }
        }
        
    }
}
