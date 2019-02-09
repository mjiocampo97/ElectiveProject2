using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.ClothesService
{
    public class MockClothesService : IClothesService
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Storage.db3");


        public UserAccount GetClothesDataBase<T>(T user)
        {
            throw new NotImplementedException();
        }
    }
}
