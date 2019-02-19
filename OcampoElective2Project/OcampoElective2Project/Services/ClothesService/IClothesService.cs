using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.ClothesService
{
    public interface IClothesService 
    {
        Clothes GetClothesDataBase<T>(T user);
        List<Clothes> GetClothesUser(UserAccount clothesUnderUser);
        void AddClothes(Clothes clothes);
        void DeleteClothes(Clothes clothes);
        void UpdateClothes(Clothes oldClothes, Clothes newClothes);
    }
}
