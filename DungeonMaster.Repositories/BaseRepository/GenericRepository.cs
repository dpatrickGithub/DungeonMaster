namespace DungeonMaster.Repositories
{
    using DungeonMaster.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseModel
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbSet = context.Set<T>();
        }

        public virtual T Add(T entity) => _dbSet.Add(entity).Entity;

        public T Delete(T entity) => _dbSet.Remove(entity).Entity;

        public void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual IEnumerable<T> GetAll() => _dbSet.AsEnumerable<T>();

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
