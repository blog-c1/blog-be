namespace blog_be.PostManagement.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Message { get; set; }

        public int PostId { get; set; }
    }
}