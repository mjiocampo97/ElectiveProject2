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

        public List<Food> GetFoodUser(UserAccount foodUnderUser)
        {

            var foods = _repository.Food.GetRange(c => c.UserId == foodUnderUser.AccountId);
            return foods;
           
        }

        public void AddFood(Food food)
        {
            _repository.Food.Add(food);
        }

        public void DeleteFood(Food food)
        {
            _repository.Food.Delete(c => c.Id == food.Id);
        }

        public void UpdateFood(Food oldFood, Food newFood)
        {
            _repository.Food.Update(c => c.Id == oldFood.Id, newFood);
        }
    }
}
