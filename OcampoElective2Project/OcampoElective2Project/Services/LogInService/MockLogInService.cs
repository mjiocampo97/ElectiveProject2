using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using SQLite;

namespace OcampoElective2Project.Services.LogInService
{
    public class MockLogInService : ILogInService
    {

        public ObservableCollection<UserAccount> Users { get;} = new ObservableCollection<UserAccount>();

        //TODO:field dapat
        private IDataService<UserAccount> _UserAccountDataService{ get; }

        public UserAccount Check(string username, string password)
        {
            var user = Users.FirstOrDefault(c => c.Username == username && c.Password == password);
            return user;
        }

        public void CreateFakeUserAccount()
        {
            Users.Add(new UserAccount("Mark","Ocampo",new DateTime(1997,6,18),123123,123,"1","1","mjiocampo@addu.edu.ph" ));
        }

        public void GetFromDatabaseUseraccount<T>(T user)
        {
         
        //  DataService.Add(DataService.Add());
           return;
        }

        public MockLogInService()
        {
            CreateFakeUserAccount();
        }
    }
}
