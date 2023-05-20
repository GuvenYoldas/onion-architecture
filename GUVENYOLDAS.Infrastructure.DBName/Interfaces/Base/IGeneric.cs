using GUVENYOLDAS.Core.DBName.Entities.Base;
using System.Linq.Expressions;

namespace GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base
{
    public interface IGeneric<TEntity, in TKey> where TEntity : BaseEntity
    {
        void Create(TEntity entity);
        TEntity Created(TEntity entity);

        void Update(TEntity entity);

        void Delete(TKey id);

        void Delete(TEntity entity);
        void DeleteAll(IEnumerable<TEntity> entities);
        void SoftDelete(TKey id);

        void SoftDelete(TEntity entity);
        void SoftDeleteAll(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E");

        Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E");

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E");

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            string isActive = "E");

        TEntity GetOne(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            string isActive = "E");

        Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            string isActive = "E");

        TEntity GetFirst(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            string isActive = "E");

        Task<TEntity> GetFirstAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            string isActive = "E");

        TEntity GetById(
            TKey id,
            string isActive = "E");

        Task<TEntity> GetByIdAsync(
            TKey id,
            string isActive = "E");

        int GetCount(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E");

        Task<int> GetCountAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E");

        bool GetExists(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E");

        Task<bool> GetExistsAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E");
    }
}
