using FakeRedditApp.Data.FileStorage;
using FakeRedditApp.Data.Models;

namespace FakeRedditApp.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly JsonFileStorage<User> _fileStorage;
        private readonly string _filePath = "users.json";

        public UserRepository()
        {
            _fileStorage = new JsonFileStorage<User>(_filePath);
        }

        public List<User> GetAll()
        {
            return _fileStorage.ReadFromFile();
        }

        public User GetById(string id)
        {
            return GetAll().FirstOrDefault(u => u.Id == id);
        }

        public void Add(User item)
        {
            var users = GetAll();
            users.Add(item);
            _fileStorage.WriteToFile(users);
        }

        public void Update(User item)
        {
            var users = GetAll();
            var index = users.FindIndex(u => u.Id == item.Id);
            if (index != -1)
            {
                users[index] = item;
                _fileStorage.WriteToFile(users);
            }
        }

        public void Delete(string id)
        {
            var users = GetAll();
            users.RemoveAll(u => u.Id == id);
            _fileStorage.WriteToFile(users);
        }
    }
}
