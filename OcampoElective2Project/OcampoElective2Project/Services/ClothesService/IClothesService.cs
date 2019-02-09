using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.ClothesService
{
    public interface IClothesService
    {
        UserAccount GetClothesDataBase<T>(T user);

    }
}
