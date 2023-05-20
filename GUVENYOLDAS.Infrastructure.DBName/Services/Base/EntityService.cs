using GUVENYOLDAS.Core.DBName.Entities.Base;
using GUVENYOLDAS.Core.DBName.Interfaces.Base;
using GUVENYOLDAS.Infrastructure.DBName.Interfaces.Base;
using System.Linq.Expressions;

namespace GUVENYOLDAS.Infrastructure.DBName.Services.Base
{
    public abstract class EntityService<TEntity, TKey> : IGeneric<TEntity, TKey> where TEntity : BaseEntity, IBaseAuditable
    {
        IUnitOfWork _unitOfWork;

        IGeneric<TEntity, TKey> _genericRepository;

        public EntityService(IUnitOfWork unitOfWork, IGeneric<TEntity, TKey> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public void Create(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }

            _genericRepository.Create(entity);
            _unitOfWork.Save();
        }
        public TEntity Created(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            _genericRepository.Created(entity);
            _unitOfWork.Save();
            return entity;
        }
        public async Task CreateAsync(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }

            _genericRepository.Create(entity);
            await _unitOfWork.SaveAsync();
        }

        public void Update(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            try
            {
                _genericRepository.Update(entity);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }

            _genericRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public void Delete(TKey id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                Delete(entity);
            }
            else
            {
                throw new ArgumentNullException("entity");
            }
        }

        public void Delete(TEntity entity)
        {
            _genericRepository.Delete(entity);
            _unitOfWork.Save();


        }
        public void DeleteAll(IEnumerable<TEntity> entities)
        {

            _genericRepository.DeleteAll(entities);
            _unitOfWork.Save();

        }
        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                await DeleteAsync(entity);
            }
            else
            {
                throw new ArgumentNullException("entity");
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {

            _genericRepository.Delete(entity);
            await _unitOfWork.SaveAsync();

        }

        public void SoftDelete(TKey id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                SoftDelete(entity);
            }
            else
            {
                throw new ArgumentNullException("entity");
            }
        }

        public void SoftDelete(TEntity entity)
        {
            _genericRepository.SoftDelete(entity);
            _unitOfWork.Save();
        }

        public void SoftDeleteAll(IEnumerable<TEntity> entity)
        {
            _genericRepository.SoftDeleteAll(entity);
            _unitOfWork.Save();
        }

        public async Task SoftDeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                await SoftDeleteAsync(entity);
            }
            else
            {
                throw new ArgumentNullException("entity");
            }
        }

        public async Task SoftDeleteAsync(TEntity entity)
        {
            _genericRepository.SoftDelete(entity);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            string isActive = "E")
        {
            return _genericRepository.GetAll(orderBy, includeProperties, skip, take, isActive);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            string isActive = "E")
        {
            return await _genericRepository.GetAllAsync(orderBy, includeProperties, skip, take, isActive);
        }


        /// <summary>
        /// tüm select sorguları buradan yapılır
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            string isActive = "E")
        {
            return _genericRepository.Get(filter, orderBy, includeProperties, skip, take, isActive);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = default(int?),
            int? take = default(int?),
            string isActive = "E")
        {
            return await _genericRepository.GetAsync(filter, orderBy, includeProperties, skip, take, isActive);
        }

        public TEntity GetOne(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            string isActive = "E")
        {
            return _genericRepository.GetOne(filter, includeProperties, isActive);
        }

        public async Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            string isActive = "E")
        {
            return await _genericRepository.GetOneAsync(filter, includeProperties, isActive);
        }

        public TEntity GetFirst(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            string isActive = "E")
        {
            return _genericRepository.GetFirst(filter, orderBy, includeProperties, isActive);
        }

        public async Task<TEntity> GetFirstAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            string isActive = "E")
        {
            return await _genericRepository.GetFirstAsync(filter, orderBy, includeProperties, isActive);
        }

        public TEntity GetById(
            TKey id,
            string isActive = "E")
        {
            return _genericRepository.GetById(id, isActive);
        }

        public async Task<TEntity> GetByIdAsync(
            TKey id,
            string isActive = "E")
        {
            return await _genericRepository.GetByIdAsync(id, isActive);
        }

        public int GetCount(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")
        {
            return _genericRepository.GetCount(filter, isActive);
        }

        public async Task<int> GetCountAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")
        {
            return await _genericRepository.GetCountAsync(filter, isActive);
        }

        public bool GetExists(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")
        {
            return _genericRepository.GetExists(filter, isActive);
        }

        public async Task<bool> GetExistsAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string isActive = "E")
        {
            return await _genericRepository.GetExistsAsync(filter, isActive);
        }
    }
}
