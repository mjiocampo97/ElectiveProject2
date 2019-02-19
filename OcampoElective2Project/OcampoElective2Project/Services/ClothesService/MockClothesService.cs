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
         
            var clothes = _repository.Clothes.GetRange(c=>c.UserId == clothesUnderUser.AccountId);
            return clothes;
            var clothes2 = _repository.Clothes.GetAll();
            clothes2.Add(new Clothes()
            {
                UserId = 81,
                Name =  "81 shirt",
                Price = 91000
            });
          //  return clothes;
         //   var listclothes
            var clothesForUser = new List<Clothes>();
            foreach (var v in clothes2)
            {
                if(v.UserId == clothesUnderUser.AccountId)
               clothesForUser.Add(v);
                else
                {
                    
                }
            }
        
           
             
            

            return clothesForUser;
        }

        public void AddClothes(Clothes clothes)
        {
            _repository.Clothes.Add(clothes);
        }

        public void DeleteClothes(Clothes clothes)
        {
            _repository.Clothes.Delete(c=>c.Id == clothes.Id);
        }

        public void UpdateClothes(Clothes clothes)
        {
            throw new NotImplementedException();
        }

        public void UpdateClothes(Clothes oldClothes, Clothes newClothes)
        {
            _repository.Clothes.Update(c=> c.Id == oldClothes.Id, newClothes);
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
