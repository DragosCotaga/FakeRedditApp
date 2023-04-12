using FakeRedditApp.Data.Models;
using FakeRedditApp.Data.Repositories;

namespace FakeRedditApp.Services
{
    public class SubForumService
    {
        private readonly SubForumRepository _subForumRepository;

        public SubForumService(SubForumRepository subForumRepository)
        {
            _subForumRepository = subForumRepository;
        }

        public List<SubForum> GetAllSubForums()
        {
            return _subForumRepository.GetAll();
        }

        public SubForum GetSubForumById(string id)
        {
            return _subForumRepository.GetById(id);
        }

        public void AddSubForum(SubForum subForum)
        {
            _subForumRepository.Add(subForum);
        }

        public void UpdateSubForum(SubForum subForum)
        {
            _subForumRepository.Update(subForum);
        }

        public void DeleteSubForum(string id)
        {
            _subForumRepository.Delete(id);
        }
    }
}
