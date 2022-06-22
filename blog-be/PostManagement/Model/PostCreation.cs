namespace blog_be.PostManagement.Model
{
    public class PostCreation
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int Category_Id { get; set; }
    }
}
