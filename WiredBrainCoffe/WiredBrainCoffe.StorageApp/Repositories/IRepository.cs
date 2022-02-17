using System.Collections.Generic;
using WiredBrainCoffe.StorageApp.Entities;

namespace WiredBrainCoffe.StorageApp.Repositories
{
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {
    }

}