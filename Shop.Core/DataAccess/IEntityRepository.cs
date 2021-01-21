using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shop.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);

        /// <summary>
        /// Checks whether the values of the specified properties have changed.
        /// </summary>
        /// <param name="entity">The IEntity object.</param>
        /// <param name="properties">The properties to check.</param>
        /// <returns>If the value of any property has edited, true; otherwise, false.</returns>
        bool IsPropertiesEdited(T entity, params string[] properties);
    }
}
