namespace FakeRedditApp.Data.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public string SubForumId { get; set; } // Optional feature
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
    }
}
