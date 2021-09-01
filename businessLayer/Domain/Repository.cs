using Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Domain
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            //dbContext.Configuration.LazyLoadingEnabled = true;
        }
        public  IQueryable<T> All()
        {
            return _dbSet.AsQueryable();
        }
        public  IQueryable<T> AsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }
        public  T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public  ValueTask<T> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id);
        }
        public  IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }
        public EntityEntry<T> Create(T entity)
        {
            var  newEntry = _dbSet.Add(entity);
            return newEntry;
        }
        public  void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }
        public  void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }
        //public  void Update(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentException("Cannot update a null entity.");
        //    }

        //    //_dbSet.Local.Clear();
        //    //_dbSet.Attach(entity);
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //}

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Reload(T entity)
        {
            _dbContext.Entry(entity).Reload();
        }
    }
}
