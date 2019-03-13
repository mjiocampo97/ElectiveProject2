using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;

namespace OcampoElective2Project.Services.FoodService
{
    public class MockFoodService : IFoodService
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");

        private IRepository _repository;

        public MockFoodService()
        {
            _repository = new LocalRepository();
        }

        public List<Food> GetFoodUser(UserAccount clothesUnderUser)
        {

            var foods = _repository.Food.GetRange(c => c.UserId == clothesUnderUser.AccountId);
            return foods;
           
        }

        public void AddFood(Food food)
        {
            throw new NotImplementedException();
        }

        public void DeleteFood(Food food)
        {
            throw new NotImplementedException();
        }

        public void UpdateFood(Food oldFood, Food newFood)
        {
            throw new NotImplementedException();
        }
    }
}
