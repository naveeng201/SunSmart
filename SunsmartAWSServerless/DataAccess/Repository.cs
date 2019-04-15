using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SunsmartAWSServerless.EntityModels;

namespace SunsmartAWSServerless.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SunsmartContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(SunsmartContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        /// <summary>
        /// Fetch all data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        /// <summary>
        /// Fetch a specific value based on primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            return entities.Find(id);
        }

        /// <summary>
        /// Insert an entity to DB
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Find an entity based on given predicate
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
             return this.context.Set<T>().Where(expression);
        }

    }
}
