using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NominaSoft.Core.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Condicion { get; }
    }
}
