using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SunsmartAWSServerless.DataAccess
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Fetch all data
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Fetch a specific entity based on primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Insert an entity to DB
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Find an entity based on given predicate
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
