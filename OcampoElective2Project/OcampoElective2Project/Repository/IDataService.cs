﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OcampoElective2Project.Repository
{
    public interface IDataService<T> where T : class 
    {
        void Add(T record);

        T Get();

        int Update();

        int Delete();

        List<T> GetAll();

        List<T> GetRange(Expression<Func<T, bool>> condition);
    }
}