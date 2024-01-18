using ILC.BL.IRepo;
using ILC.Domain.DBEntities;
using ILC.Domain.DBCommon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ILC.BL.Repo
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class, new()
    {
        protected readonly ILCContext _context;

        public GenericRepo(ILCContext context)
        {
            _context = context;
        }

        public bool CheckExists(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                IQueryable<TEntity> query = _context.Set<TEntity>();
                if (typeof(TEntity).GetInterfaces().Contains(typeof(ISoftDeletable)))
                {
                    query = query.Where(p => ((ISoftDeletable)p).IsDeleted != true);
                }
                if (predicate != null)
                {
                    return query.Any(predicate);
                }
                return query.Any();
            }
            catch
            {
                return false;
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            if (typeof(TEntity).GetInterfaces().Contains(typeof(ISoftDeletable)))
            {
                return _context.Set<TEntity>().Where(p => ((ISoftDeletable)p).IsDeleted != true);
            }
            return _context.Set<TEntity>().AsQueryable();
        }
        public virtual TEntity GetById(params object[] keys)
        {
            try
            {
                return _context.Find<TEntity>(keys);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public virtual async Task<TEntity> GetByIdAsync(params object[] keys)
        {
            try
            {
                return await _context.FindAsync<TEntity>(keys);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null, bool asNoTracking = false, bool splitQuery = false, params Expression<Func<TEntity, object>>[] joins)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            foreach (var join in joins)
            {
                query = query.Include(join);
            }
            if (typeof(TEntity).GetInterfaces().Contains(typeof(ISoftDeletable)))
            {
                query = query.Where(p => ((ISoftDeletable)p).IsDeleted != true);
            }
            if (predicate is not null)
            {
                query = query.Where(predicate);
            }
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            if (splitQuery)
            {
                query = query.AsSplitQuery();
            }
            return query;
        }
        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> predicate = null, bool asNoTracking = false, bool splitQuery = false, params Expression<Func<TEntity, object>>[] joins)
        {
            return Find(predicate, asNoTracking, splitQuery, joins).FirstOrDefault();
        }
        public virtual TEntity Insert(TEntity record)
        {
            try
            {
                _context.Set<TEntity>().Add(record);
                return record;
            }
            catch
            {
                return null;
            }
        }
        public virtual async Task<TEntity> InsertAsync(TEntity record, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(record, cancellationToken);
                return record;
            }
            catch
            {
                return null;
            }
        }
        public virtual void InsertMany(IEnumerable<TEntity> records)
        {
            try
            {
                _context.Set<TEntity>().AddRange(records);
            }
            catch
            {

            }
        }
        public virtual void InsertMany(params TEntity[] records)
        {
            InsertMany(records.AsEnumerable());
        }

        public virtual async Task InsertManyAsync(IEnumerable<TEntity> records, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Set<TEntity>().AddRangeAsync(records, cancellationToken);
            }
            catch
            {

            }
        }
        public virtual async Task InsertManyAsync(params TEntity[] records)
        {
            await InsertManyAsync(records.AsEnumerable());
        }
        //public virtual void Update(TEntity record)
        //{
        //    try
        //    {
        //        _context.Set<TEntity>().Attach(record);
        //        _context.Entry(record).State = EntityState.Modified;
        //    }
        //    catch
        //    {
        //    }
        //}

        public virtual void Update(TEntity record, params Expression<Func<TEntity, object>>[] ignoredProperties)
        {
            try
            {
                var entry = _context.Entry(record);
                entry.State = EntityState.Modified;
                foreach (var prop in ignoredProperties)
                {
                    entry.Property(prop).IsModified = false;
                }
            }
            catch
            {
            }
        }

        public virtual void UpdateUntracked(TEntity record, params Expression<Func<TEntity, object>>[] specificProperties)
        {
            try
            {
                var entry = _context.Attach(record);
                if (specificProperties?.Length > 0)
                {
                    entry.State = EntityState.Unchanged;
                    foreach (var prop in specificProperties)
                    {
                        entry.Property(prop).IsModified = true;
                    }
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
            catch { }
        }




        public virtual void Delete(TEntity record)
        {
            try
            {
                if (record is ISoftDeletable softDeletable)
                {
                    softDeletable.IsDeleted = true;
                    Update(record);
                }
                else
                {
                    _context.Set<TEntity>().Remove(record);
                }
            }
            catch
            {

            }
        }
        public virtual void DeleteMany(IEnumerable<TEntity> records)
        {
            try
            {
                if (typeof(TEntity).GetInterfaces().Contains(typeof(ISoftDeletable)))
                {
                    records.ToList().ForEach(p =>
                    {
                        ((ISoftDeletable)p).IsDeleted = true;
                        Update(p);
                    });
                }
                else
                {
                    _context.Set<TEntity>().RemoveRange(records);
                }
            }
            catch
            {

            }
        }
        public virtual void DeleteMany(params TEntity[] records)
        {
            DeleteMany(records.AsEnumerable());
        }

        public virtual void DeleteAll()
        {
            _context.Set<TEntity>().RemoveRange(_context.Set<TEntity>());
        }

        public virtual IQueryable<TEntity> FindAndJoin(Expression<Func<TEntity, bool>> predicate = null, bool splitQuery = false, params Expression<Func<TEntity, object>>[] joins)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            foreach (var join in joins)
            {
                query = query.Include(join);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (splitQuery && joins.Length > 0)
            {
                query = query.AsSplitQuery();
            }

            return query;
        }

        public virtual int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public virtual async Task<int> SaveAsync(CancellationToken stoppingToken = default)
        {
            try
            {
                return await _context.SaveChangesAsync(stoppingToken);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }



        public virtual void Attach(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
        }

        public virtual void Untrack(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public virtual void Join(ref TEntity entity, params Expression<Func<TEntity, object>>[] joins)
        {
            foreach (var j in joins)
            {
                _context.Entry(entity).Reference(j).Load();
            }
        }

        public virtual void JoinCollection(ref TEntity entity, params Expression<Func<TEntity, object>>[] joins)
        {
            foreach (var j in joins)
            {
                _context.Entry(entity).Reference(j).Load();
            }
        }

        public void removeFromDatabase(TEntity record)
        {
            try
            {
                _context.Set<TEntity>().Remove(record);
            }
            catch
            {

            }
        }
    }
}
