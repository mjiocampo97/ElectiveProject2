using System;
using System.Collections.Generic;
using System.Text;

namespace OcampoElective2Project.Repository.OnlineRepository
{
    public class OnlineDataService<T> : IDataService<T> where T : class, new()
    {
        public void Add(T record)
        {
            throw new NotImplementedException();
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
