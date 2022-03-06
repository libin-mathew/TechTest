
using System;
using System.Linq;
using System.Collections.Generic;


namespace Interview.RepoCore
{
    /// <summary>
    ///  Repository handler
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private List<T> _dataRepo;

        public Repository()
        {
            _dataRepo = new List<T>();
        }
        /// <summary>
        /// Get All the Items from Repository 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> All()
        {
            return _dataRepo;
        }
        /// <summary>
        /// Delete an item from Repository
        /// </summary>
        /// <param name="id"></param>
        public void Delete(IComparable id)
        {
            T item = _dataRepo.FirstOrDefault(e => e.Id == id);
            _dataRepo.Remove(item);
        }
        /// <summary>
        /// Get an item from Repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(IComparable id)
        {
            T entity = _dataRepo.FirstOrDefault(e => e.Id == id);
            return entity;
        }
        /// <summary>
        /// Save new item to the Repository
        /// </summary>
        /// <param name="entity"></param>
        public void Save(T entity)
        {
            _dataRepo.Add(entity);
        }
    }
}
