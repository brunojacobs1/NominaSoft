using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NominaSoft.Core.Interfaces
{
    public interface IRepository<T> where T: class
    {
        T GetById(int id);
        IEnumerable<T> List();
        T Get(ISpecification<T> spec);
        IEnumerable<T> List(ISpecification<T> spec);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
