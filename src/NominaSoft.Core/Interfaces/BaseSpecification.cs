using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NominaSoft.Core.Interfaces
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Condicion { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, Object>> Extra { get; }
        public BaseSpecification(Expression<Func<T, bool>> _condicion) => Condicion = _condicion;
        protected virtual void AddInclude(Expression<Func<T, object>> _include) => Includes.Add(_include);

        public BaseSpecification(Expression<Func<T, Object>> extra)
        {
            Extra = extra;
        }
        public BaseSpecification(Expression<Func<T, bool>> condicion, Expression<Func<T, Object>> extra)
        {
            Extra = extra;
            Condicion = condicion;
        }
    }
}
