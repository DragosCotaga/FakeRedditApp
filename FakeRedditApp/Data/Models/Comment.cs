namespace FakeRedditApp.Data.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
    }
}
