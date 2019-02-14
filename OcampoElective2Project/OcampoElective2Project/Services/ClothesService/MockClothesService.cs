using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;
using SQLite;

namespace OcampoElective2Project.Services.ClothesService
{
    public class MockClothesService : IClothesService
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");

        private IRepository _repository;
        public MockClothesService()
        {
            _repository = new LocalRepository();
        }
        public Clothes GetClothesDataBase<T>(T user)
        {
            throw new NotImplementedException();
        }

        public List<Clothes> GetClothesUser(UserAccount clothesUnderUser)
        {
         
            var clothes = _repository.Clothes.GetRange(c=>c.UserId== clothesUnderUser.AccountId);
            return clothes;
            var clothesForUser = new List<Clothes>();
           
               clothesForUser.AddRange(clothes.Where(c=> c.UserId == clothesUnderUser.AccountId)); 
            

            return clothesForUser;
        }

        //public List<Clothes> GetClothesOfUser()
        //{
        //    Clothes clothesu 
        //    var clothesTables = _repository.UserAccount.GetRange(c => c.AccountId == clothes.UserId);
        //    var clothesList = new List<Clothes>();
        //    {
        //        foreach (var VARIABLE in clothesTables)
        //        {
        //            clothesList.Add(_repository.Clothes.Get(c => c.UserId == clothes.Id));
        //        }

        //        return clothesList;
        //    }
        //}
    }
}
