using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OcampoElective2Project.Repository
{
    public interface IDataService<T> where T : class 
    {
        void Add(T record);

        T Get(Expression<Func<T, bool>> condition);

        void Update(Expression<Func<T, bool>> condition, T newObject);

        void Delete(Expression<Func<T, bool>> condition);

        List<T> GetAll();

        List<T> GetRange(Expression<Func<T, bool>> condition);
    }
}
