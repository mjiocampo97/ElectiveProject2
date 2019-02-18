using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.FoodService
{
    public interface IFoodService
    {
        List<Food> GetFoodUser(UserAccount clothesUnderUser);
    }
}
