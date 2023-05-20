using GUVENYOLDAS.Core.DBName.Entities.Base;
using GUVENYOLDAS.Data.DBName;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GUVENYOLDAS.Infrastructure.DBName.Repositories.Base
{
    public abstract class GenericRepository<TEntity, TKey> : IGeneric<TEntity, TKey> where TEntity : BaseEntity
    {
        //protected readonly DbContext _context;
        protected readonly DBNameDbContext _context;

        public GenericRepository(DBNameDbContext context)
        {
            _context = context;
            //_secondDbContext = context;
        }

        public virtual void Create(TEntity entity)
        {
            //entity.CreatedDateOffsetUtc = DateTimeOffset.UtcNow;
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity Created(TEntity entity)
        {
            // entity.CreatedDateOffsetUtc = DateTimeOffset.UtcNow;
            _context.Set<TEntity>().Add(entity);
            return entity;
        }
        public virtual void Update(TEntity entity)
        {
            // entity.UpdatedDateOffsetUtc = DateTimeOffset.UtcNow;

            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TKey id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            var dbSet = _context.Set<TEntity>();
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void DeleteAll(IEnumerable<TEntity> entities)
        {
            var dbSet = _context.Set<TEntity>();

            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Remove(entity);
                }
                dbSet.Remove(entity);
            }

        }

        public void SoftDelete(TKey id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            SoftDelete(entity);
        }

        public void SoftDelete(TEntity entity)
        {
            // entity.UpdatedDateOffsetUtc = DateTime.UtcNow;
            // entity.IsActive = "H";
            Update(entity);
        }

        public virtual void SoftDeleteAll(IEnumerable<TEntity> entities)
        {
            var dbSet = _context.Set<TEntity>();

            foreach (var entity in entities)
            {
                //    entity.UpdatedDateOffsetUtc = DateTime.UtcNow;
                //    entity.IsActive = "H";
                Update(entity);
            }

        }

        protected virtual IQueryable<TEntity> GetQueryable(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          string includeProperties = null,
          int? skip = null,
          int? take = null,
          string isActive = "E")

        {
            try
            {
                // _context.ChangeTracker.AutoDetectChangesEnabled = false;

                includeProperties = includeProperties ?? string.Empty;
                IQueryable<TEntity> query = _context.Set<TEntity>();

                query.AsNoTracking();

                if (isActive != "E")
                {
                    // query = query.Where(q => q.IsActive == isActive);
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                if (skip.HasValue)
                {
                    query = query.Skip(skip.Value);
                }

                if (take.HasValue)
                {
                    query = query.Take(take.Value);
                }

                return query;
            }
            finally
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public virtual IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E")

        {
            return GetQueryable(
                filter: null,
                orderBy: orderBy,
                includeProperties: includeProperties,
                skip: skip,
                take: take,
                isActive: isActive)
                .ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E")

        {
            return await GetQueryable(
                filter: null,
                orderBy: orderBy,
                includeProperties: includeProperties,
                skip: skip,
                take: take,
                isActive: isActive)
                .ToListAsync();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E")

        {
            return GetQueryable(
                filter: filter,
                orderBy: orderBy,
                includeProperties: includeProperties,
                skip: skip,
                take: take,
                isActive: isActive)
                .ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E")

        {
            return await GetQueryable(
                filter: filter,
                orderBy: orderBy,
                includeProperties: includeProperties,
                skip: skip,
                take: take,
                isActive: isActive)
                .ToListAsync();
        }

        public virtual TEntity GetOne(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "",
            string isActive = "E")

        {
            return GetQueryable(
                filter: filter,
                orderBy: null,
                includeProperties: includeProperties,
                isActive: isActive)
                .SingleOrDefault();
        }

        public virtual async Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            string isActive = "E")

        {
            return await GetQueryable(
                filter: filter,
                orderBy: null,
                includeProperties: includeProperties,
                isActive: isActive)
                .SingleOrDefaultAsync();
        }

        public virtual TEntity GetFirst(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = null,
           string isActive = "E")

        {
            return GetQueryable(
                filter: filter,
                orderBy: orderBy,
                includeProperties: includeProperties,
                isActive: isActive)
                .FirstOrDefault();
        }

        public virtual async Task<TEntity> GetFirstAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            string isActive = "E")

        {
            return await GetQueryable(
                filter: filter,
                orderBy: orderBy,
                includeProperties: includeProperties,
                isActive: isActive)
                .FirstOrDefaultAsync();
        }

        public virtual TEntity GetById(
            TKey id,
            string isActive = "E")

        {
            var query = _context.Set<TEntity>().Find(id);

            if (isActive != "E")
            {
                return null;
            }

            return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(
            TKey id,
            string isActive = "E")

        {
            var query = await _context.Set<TEntity>().FindAsync(id);

            if (isActive != "E")
            {
                return null;
            }

            return query;
        }

        public virtual int GetCount(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")

        {
            return GetQueryable(
                filter: filter,
                isActive: isActive)
                .Count();
        }

        public virtual async Task<int> GetCountAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")

        {
            return await GetQueryable(
                filter: filter,
                isActive: isActive)
                .CountAsync();
        }

        public virtual bool GetExists(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")

        {
            return GetQueryable(
                filter: filter,
                isActive: isActive)
                .Any();
        }

        public virtual async Task<bool> GetExistsAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")

        {
            return await GetQueryable(
                filter: filter,
                isActive: isActive)
                .AnyAsync();
        }

    }
}
