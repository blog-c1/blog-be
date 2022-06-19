namespace blog_be.PostManagement.Model;
using Microsoft.EntityFrameworkCore;

[Keyless]
    public class PostInfo
    {
        public   int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public string CategoryName { get; set; }
    }

