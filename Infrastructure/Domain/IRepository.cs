using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Domain
{
    public interface IRepository<T> where T : class
    {
        public abstract IQueryable<T> All();
        public abstract IQueryable<T> AsNoTracking();
        public abstract T GetById(object id);
        public abstract ValueTask<T> GetByIdAsync(object id);
        public abstract EntityEntry<T> Create(T entity);
        public abstract IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        public abstract void Delete(object id);
        public abstract void Delete(T entity);
        public abstract void Reload(T entity);
       
        public abstract void Update(T entity);
    }
}
