using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext Context { get; set; }
        public RepositoryBase(DbContext context)
        {
            Context = context;
        }
        public T Create(T entity) =>
            Context.Set<T>().Add(entity).Entity;

        public void Delete(T entity) =>
            Context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() =>
            Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();
        public void Update(T entity) =>
            Context.Set<T>().Update(entity);

        public IQueryable<T> ExecuteSP(string sql) =>
            Context.Set<T>().FromSqlRaw<T>(sql);
    }
}
