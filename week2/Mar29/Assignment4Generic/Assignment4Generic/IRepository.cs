using System;
namespace Assignment4Generic
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class DataSource<T> where T : Entity
    {
        protected List<T> Data;

        protected DataSource()
        {
            Data = new List<T>();
        }

        public abstract void Save();
    }

    public class GenericRepository<T> : DataSource<T>, IRepository<T> where T : Entity
    {
        public void Add(T item)
        {
            Data.Add(item);
        }

        public void Remove(T item)
        {
            Data.Remove(item);
        }

        public override void Save()
        {
            // Save changes to the data source (e.g., database)
        }

        public IEnumerable<T> GetAll()
        {
            return Data.AsReadOnly();
        }

        public T GetById(int id)
        {
            return Data.FirstOrDefault(e => e.Id == id);
        }
    }


    public class MyEntity : Entity
    {
        public string Name { get; set; }
    }

}

