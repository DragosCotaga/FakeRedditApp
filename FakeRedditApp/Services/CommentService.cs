using FakeRedditApp.Data.Models;
using FakeRedditApp.Data.Repositories;

namespace FakeRedditApp.Services
{
    public class CommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<Comment> GetAllComments()
        {
            return _commentRepository.GetAll();
        }

        public Comment GetCommentById(string id)
        {
            return _commentRepository.GetById(id);
        }

        public void AddComment(Comment comment)
        {
            _commentRepository.Add(comment);
        }

        public void UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
        }

        public void DeleteComment(string id)
        {
            _commentRepository.Delete(id);
        }
    }
}
