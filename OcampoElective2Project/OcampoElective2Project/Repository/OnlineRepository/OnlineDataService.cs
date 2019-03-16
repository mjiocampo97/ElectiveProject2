using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OcampoElective2Project.Repository.OnlineRepository
{
    public class OnlineDataService<T> : IDataService<T> where T : class, new()
    {
        public void Add(T record)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public void Update(Expression<Func<T, bool>> condition, T newObject)
        {
            throw new NotImplementedException();
        }

        public void Update(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }


        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetRange(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
