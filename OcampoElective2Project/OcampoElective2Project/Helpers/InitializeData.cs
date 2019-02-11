using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OcampoElective2Project.Models;
using SQLite;

namespace OcampoElective2Project.Helpers
{
    public class InitializeData
    {
        private static string dbPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Storage.db3");

        public bool IsTestMode;
        
        public InitializeData()
        {
            if (IsTestMode == true)
            {
                var connection = new SQLiteAsyncConnection(dbPath);
                connection.CreateTableAsync<Food>();
                connection.CreateTableAsync<Clothes>();
                connection.CreateTableAsync<Others>();
                connection.CreateTableAsync<Transportation>();
                connection.CreateTableAsync<UserAccount>();

                var clothes = connection.Table<Clothes>();
                var listOfClothes = clothes.ToListAsync();
               

            }

        }


        private void CreateMockDataSQL(SQLiteConnection connection)
        {
            for (int i = 0; i < 3; i++)
            {
                connection.Insert(new Clothes()
                {
                    Name = $" Clothes {i}",
                    Price= i * 100,
                    UserId=0
                });
            }
        }
    }
}
