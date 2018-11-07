using System.Collections.Generic;
using System.Threading.Tasks;
using SamMiller.Mumba.Api.Core.Entities;

namespace SamMiller.Mumba.Api.Core.Data
{
    /// <summary>
    /// The class that defines the Async repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IAsyncRepository<T, TKey> where T : IEntity<TKey>
    {
        /// <summary>
        /// The task for retrieving a item by its id
        /// </summary>
        /// <param name="id">A Guid</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(TKey id);

        /// <summary>
        /// The task to list all IEnumerables in the repository
        /// </summary>
        /// <returns></returns>       
        Task<IEnumerable<T>> ListAllAsync();

        /// <summary>
        /// Adds an entity to the repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates an Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

    }
}