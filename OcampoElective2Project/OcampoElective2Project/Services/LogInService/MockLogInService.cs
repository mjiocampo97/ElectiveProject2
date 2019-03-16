using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;
using SQLite;

namespace OcampoElective2Project.Services.LogInService
{
    public class MockLogInService : ILogInService
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");

        private IRepository _repository;
        public ObservableCollection<UserAccount> Users { get;} = new ObservableCollection<UserAccount>();

        public MockLogInService()
        {
      
            _repository = new LocalRepository();
            CreateFakeUserAccount();
        }
        //TODO:field dapat

        private IDataService<UserAccount> _UserAccountDataService{ get; }

        public UserAccount Check(string username, string password)
        {
            var user = _repository.UserAccount.GetAll().FirstOrDefault(c => c.Username == username && c.Password == password);
            return user;
        }

        public void CreateFakeUserAccount()
        {
           // Users.Add(new UserAccount(0,"Mark","Ocampo","1997",123123,123,"1","1","mjiocampo@addu.edu.ph" ));
            foreach (var VARIABLE in _repository.UserAccount.GetAll())
            {
                Users.Add(VARIABLE);
            }
        }

        public void GetFromDatabaseUseraccount<T>(T user)
        {
         
        //  DataService.Add(DataService.Add());
           return;
        }

      
    }
}
