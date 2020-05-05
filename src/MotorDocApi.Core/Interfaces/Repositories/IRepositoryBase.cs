using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotorDocApi.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        EntityState Update(T entity, string propertyName);
        EntityState Delete(T entity);
        IQueryable<T> ExecuteSP(string sql, params object[] parameters); 
        DbContext Query();
    }
}
