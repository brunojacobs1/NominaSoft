using NominaSoft.Infraestructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NominaSoft.Infraestructure
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly NSContext _dbContext;

        public Repository(NSContext dbContext) => _dbContext = dbContext;

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(T entity)
        {
            var t = _dbContext.Set<T>().Attach(entity);
            t.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public T GetById(int id) => _dbContext.Set<T>().Find(id);

        public IEnumerable<T> List() => _dbContext.Set<T>().AsEnumerable();

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate) => _dbContext.Set<T>()
                                                                                    .Where(predicate)
                                                                                    .AsEnumerable();
    }
}
