using FakeRedditApp.Data.Models;
using FakeRedditApp.Data.Repositories;

namespace FakeRedditApp.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        public Post GetPostById(string id)
        {
            return _postRepository.GetById(id);
        }

        public async Task AddPost(Post post)
        {
            _postRepository.Add(post);
        }

        public void UpdatePost(Post post)
        {
            _postRepository.Update(post);
        }

        public void DeletePost(string id)
        {
            _postRepository.Delete(id);
        }
    }
}
