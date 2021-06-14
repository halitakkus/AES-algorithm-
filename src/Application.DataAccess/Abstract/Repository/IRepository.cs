using Application.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Abstract.Repository
{
    /// <summary>
    /// Generic repository arayüzüdür..
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    /// <typeparam name="TKey">Unique key of entity. It should be int, Guid etc.</typeparam>
    public interface IRepository<TEntity, in TKey> where TEntity : BaseEntity<TKey>
    {
        /// <summary>
        /// Id değerine göre getirir.
        /// </summary>
        /// <param name="id">Unique id value.</param>
        /// <returns></returns>
        TEntity GetById(TKey id);

        /// <summary>
        /// Liste getirir.
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetList();

        /// <summary>
        /// Yeni nesne ekleme
        /// </summary>
        /// <param name="entity">TEntity value.</param>
        /// <returns></returns>
        bool Add(TEntity entity);

        /// <summary>
        /// nesne güncelleme
        /// </summary>
        /// <param name="entity">TEntity value.</param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        ///nesne kaldırma
        /// </summary>
        /// <param name="entity">TEntity value.</param>
        /// <returns></returns>
        bool Remove(TEntity entity);

        /// <summary>
        /// KAÇ ADET VAR ? 
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// Id değerine göre nesne getirme
        /// </summary>
        /// <param name="id">Unique id value.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Get TEntity list.
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync();

        /// <summary>
        /// asenkron nesne ekleme 
        /// </summary>
        /// <param name="entity">TEntity value.</param>
        /// <returns></returns>
        Task<bool> AddAsync(TEntity entity);

        /// <summary>
        ///  asenkron nesne güncelleme 
        /// </summary>
        /// <param name="entity">TEntity value.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        ///  asenkron nesne kaldırma 
        /// </summary>
        /// <param name="entity">TEntity value.</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(TEntity entity);

        /// <summary>
        ///  asenkron nesne adeti 
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync();
    }
}
