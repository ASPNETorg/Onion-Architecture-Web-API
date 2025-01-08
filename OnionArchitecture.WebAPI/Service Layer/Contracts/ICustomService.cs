﻿namespace ServiceLayer.Contracts
{
    public interface ICustomService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid? Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
    }
}
