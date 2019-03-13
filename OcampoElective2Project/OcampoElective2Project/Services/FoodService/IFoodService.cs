using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.FoodService
{
    public interface IFoodService
    {
        List<Food> GetFoodUser(UserAccount foodUnderUser);
        void AddFood(Food food);
        void DeleteFood(Food food);
        void UpdateFood(Food oldFood, Food newFood);
    }
}
