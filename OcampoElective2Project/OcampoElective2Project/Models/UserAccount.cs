using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OcampoElective2Project.Helpers;
using SQLite;

namespace OcampoElective2Project.Models
{
    [Table("UserAccount")]
    public class UserAccount
    {
            
     ///   public ObservableCollection<object> ListOfExpenses = new ObservableCollection<object>();
     //   public ObservableCollection<Food> ListOfFoodExpenses { get; set; }= new ObservableCollection<Food>();
     //   public ObservableCollection<Clothes> ListOfClothesExpenses { get; set; }= new ObservableCollection<Clothes>();
     //   public ObservableCollection<Others> ListOfOthersExpenses = new ObservableCollection<Others>();
   //     public ObservableCollection<Transportation> ListOfTransportationExpenses = new ObservableCollection<Transportation>();

        private int _id;
        private string _firstName;
        private string _lastName;
        private int _age;
        private string _birthDate;
        private double _money;
        private double _income;
        private string _username;
        private string _password;
        private string _emailAddress;

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int AccountId { get; set; }
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
       
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public string BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public double Money
        {
            get => _money;
            set => _money = value;
        }

        public double Income
        {
            get => _income;
            set => _income = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }


        //public UserAccount(int accountid,string firstName, string lastName, string birthDate, double money, double income,string username ,string password, string emailAddress)
        //{
        //    AccountId = accountid;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    BirthDate = birthDate;
        //    Money = money;
        //    Income = income;
        //    Username = username;
        //    Password = password;
        //    EmailAddress = emailAddress;
        //}

        public UserAccount()
        {
            
        }
        
    }
}
