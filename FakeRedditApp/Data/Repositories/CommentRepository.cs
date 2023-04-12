using FakeRedditApp.Data.FileStorage;
using FakeRedditApp.Data.Models;

namespace FakeRedditApp.Data.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly JsonFileStorage<Comment> _fileStorage;
        private readonly string _filePath = "comments.json";

        public CommentRepository()
        {
            _fileStorage = new JsonFileStorage<Comment>(_filePath);
        }

        public List<Comment> GetAll()
        {
            return _fileStorage.ReadFromFile();
        }

        public Comment GetById(string id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public void Add(Comment item)
        {
            var comments = GetAll();
            comments.Add(item);
            _fileStorage.WriteToFile(comments);
        }

        public void Update(Comment item)
        {
            var comments = GetAll();
            var index = comments.FindIndex(c => c.Id == item.Id);
            if (index != -1)
            {
                comments[index] = item;
                _fileStorage.WriteToFile(comments);
            }
        }

        public void Delete(string id)
        {
            var comments = GetAll();
            comments.RemoveAll(c => c.Id == id);
            _fileStorage.WriteToFile(comments);
        }
    }
}
