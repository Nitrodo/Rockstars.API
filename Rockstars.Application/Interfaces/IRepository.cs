using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rockstars.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity Find(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMembers);
        TEntity Find(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeMembers);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        void InsertMany(IEnumerable<TEntity> entities);
        void SaveChanges();
    }
}
