using Microsoft.EntityFrameworkCore;

namespace blog_be.PostManagement.Model
{
    [Keyless]
    public class PostDetail:PostInfo
    {
        public DateTime? CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }  

        public List<Comment> Comments { get; set; }
    }
}
