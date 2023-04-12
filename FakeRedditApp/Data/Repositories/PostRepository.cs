using FakeRedditApp.Data.FileStorage;
using FakeRedditApp.Data.Models;

namespace FakeRedditApp.Data.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private readonly JsonFileStorage<Post> _fileStorage;
        private readonly string _filePath = "posts.json";

        public PostRepository()
        {
            _fileStorage = new JsonFileStorage<Post>(_filePath);
        }

        public List<Post> GetAll()
        {
            return _fileStorage.ReadFromFile();
        }

        public Post GetById(string id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public void Add(Post item)
        {
            var posts = GetAll();
            posts.Add(item);
            _fileStorage.WriteToFile(posts);
        }

        public void Update(Post item)
        {
            var posts = GetAll();
            var index = posts.FindIndex(p => p.Id == item.Id);
            if (index != -1)
            {
                posts[index] = item;
                _fileStorage.WriteToFile(posts);
            }
        }

        public void Delete(string id)
        {
            var posts = GetAll();
            posts.RemoveAll(p => p.Id == id);
            _fileStorage.WriteToFile(posts);
        }
    }
}
