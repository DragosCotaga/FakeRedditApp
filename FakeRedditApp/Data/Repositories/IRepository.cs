namespace FakeRedditApp.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(string id);
        void Add(T item);
        void Update(T item);
        void Delete(string id);
    }
}
