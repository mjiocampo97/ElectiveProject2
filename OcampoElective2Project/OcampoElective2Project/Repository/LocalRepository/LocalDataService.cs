using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
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
           // db.CreateTableAsync<T>();
            db.InsertAsync(record);
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
               return db.Get<T>(condition);
            }
        }

        public void Update(Expression<Func<T, bool>> condition, T newObject)
        {
            
            using (var db = new SQLiteConnection(dbPath))
            {
                var objectUpdate = newObject;
                db.Update(objectUpdate);
            }
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                var objectToDelete = db.Table<T>().FirstOrDefault(condition);
                db.Delete(objectToDelete);

            }
        }

        public List<T> GetAll()
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return db.Table<T>().ToList();
            }
        }

        public List<T> GetRange(Expression<Func<T,bool>> condition)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return db.Table<T>().Where(condition).ToList();
            }
        }
    }
}
