using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.IRepo
{
    public interface IGenericRepo<TEntity>
    {
        bool CheckExists(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAll();
        TEntity GetById(params object[] keys);
        Task<TEntity> GetByIdAsync(params object[] keys);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null, bool asNoTracking = false, bool splitQuery = false, params Expression<Func<TEntity, object>>[] joins);
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate = null, bool asNoTracking = false, bool splitQuery = false, params Expression<Func<TEntity, object>>[] joins);
        TEntity Insert(TEntity record);
        Task<TEntity> InsertAsync(TEntity record, CancellationToken cancellationToken = default);
        void InsertMany(IEnumerable<TEntity> records);
        void InsertMany(params TEntity[] records);
        Task InsertManyAsync(IEnumerable<TEntity> records, CancellationToken cancellationToken = default);
        Task InsertManyAsync(params TEntity[] records);
        void Update(TEntity record, params Expression<Func<TEntity, object>>[] ignoredProperties);

        void Delete(TEntity record);
        void DeleteMany(IEnumerable<TEntity> records);
        void DeleteMany(params TEntity[] records);
        void DeleteAll();
        IQueryable<TEntity> FindAndJoin(Expression<Func<TEntity, bool>> predicate = null, bool splitQuery = false, params Expression<Func<TEntity, object>>[] joins);
        int Save();
        Task<int> SaveAsync(CancellationToken stoppingToken = default);
        void Attach(TEntity entity);
        void Untrack(TEntity entity);
        void Join(ref TEntity entity, params Expression<Func<TEntity, object>>[] joins);
        void JoinCollection(ref TEntity entity, params Expression<Func<TEntity, object>>[] joins);
    }
}
