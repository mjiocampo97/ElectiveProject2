﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace OcampoElective2Project.Repository.LocalRepository
{
    public class LocalDataService<T> : IDataService<T> where T : class, new()
    {
        private static string dbPath= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Storage.db3");
       // private SQLiteAsyncConnection db = new SQLiteAsyncConnection(dbPath);
   


        public void Add(T record)
        {
            var db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<T>();
            db.InsertAsync(record);
        }

        public T Get()
        {
            throw new NotImplementedException();
        } 

        public int Update()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }
    }
}
