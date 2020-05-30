using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Interfaces.Repositories;

namespace MotorDocApi.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext Context { get; set; }

        protected RepositoryBase(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T Create(T entity) =>
            Context.Set<T>().Add(entity).Entity;

        public EntityState Delete(T entity) =>
            Context.Set<T>().Remove(entity).State;

        public IQueryable<T> FindAll() =>
            Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public EntityState Update(T entity, string propertyName)
        {
            Context.Entry<T>(entity).Property(propertyName).IsModified = false;
            return Context.Set<T>().Update(entity).State;
        }

        public IQueryable<T> ExecuteQuery(string sql) =>
            Context.Set<T>().FromSqlRaw<T>(sql);

        public void Dispose()
        {
            Context.Dispose();
            Context = null;
        }
    }
}
