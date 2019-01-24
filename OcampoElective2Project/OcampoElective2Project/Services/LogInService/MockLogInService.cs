using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.LogInService
{
    public class MockLogInService : ILogInService
    {
        public ObservableCollection<UserAccount> Users { get;} = new ObservableCollection<UserAccount>();


        public UserAccount Check(string username, string password)
        {
            var user = Users.FirstOrDefault(c => c.Username == username && c.Password == password);
            return user;
        }

        public void CreateFakeUserAccount()
        {
            Users.Add(new UserAccount("Mark","Ocampo",new DateTime(1997,6,18),123123,123,"Mark","123456","mjiocampo@addu.edu.ph" ));
        }

        public MockLogInService()
        {
            CreateFakeUserAccount();
        }
    }
}
