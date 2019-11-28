using NominaSoft.Core.Interfaces;
using NominaSoft.Infraestructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace NominaSoft.Infraestructure
{
    public class Repository<T> : IRepository<T> where T : class
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
            t.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public T GetById(int id) => _dbContext.Set<T>().Find(id);

        public T Get(ISpecification<T> spec)
        {
            var resultadoConIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                (current, include) => current.Include(include));

            return resultadoConIncludes
                .Where(spec.Condicion)
                .SingleOrDefault();
        }

        public IEnumerable<T> LastList(ISpecification<T> spec)
        {
            var resultadoConIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                (current, include) => current.Include(include));

            return resultadoConIncludes
                .Where(spec.Condicion)
                .OrderByDescending(spec.Extra)
                .Take(1);
        }

        public IEnumerable<T> SecondToLastList(ISpecification<T> spec)
        {
            var resultadoConIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                (current, include) => current.Include(include));

            return resultadoConIncludes
                .Where(spec.Condicion)
                .OrderByDescending(spec.Extra)
                .Skip(1)
                .Take(1);
        }

        public IEnumerable<T> List() => _dbContext.Set<T>().AsEnumerable();

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            var resultadoConIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                (current, include) => current.Include(include));

            return resultadoConIncludes
                .Where(spec.Condicion)
                .AsEnumerable();
        }
    }
}