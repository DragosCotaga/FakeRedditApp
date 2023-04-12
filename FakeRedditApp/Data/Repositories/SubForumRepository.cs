using FakeRedditApp.Data.FileStorage;
using FakeRedditApp.Data.Models;

namespace FakeRedditApp.Data.Repositories
{
    public class SubForumRepository : IRepository<SubForum>
    {
        private readonly JsonFileStorage<SubForum> _fileStorage;
        private readonly string _filePath = "subforums.json";

        public SubForumRepository()
        {
            _fileStorage = new JsonFileStorage<SubForum>(_filePath);
        }

        public List<SubForum> GetAll()
        {
            return _fileStorage.ReadFromFile();
        }

        public SubForum GetById(string id)
        {
            return GetAll().FirstOrDefault(sf => sf.Id == id);
        }

        public void Add(SubForum item)
        {
            var subforums = GetAll();
            subforums.Add(item);
            _fileStorage.WriteToFile(subforums);
        }

        public void Update(SubForum item)
        {
            var subforums = GetAll();
            var index = subforums.FindIndex(sf => sf.Id == item.Id);
            if (index != -1)
            {
                subforums[index] = item;
                _fileStorage.WriteToFile(subforums);
            }
        }

        public void Delete(string id)
        {
            var subforums = GetAll();
            subforums.RemoveAll(sf => sf.Id == id);
            _fileStorage.WriteToFile(subforums);
        }
    }
}
