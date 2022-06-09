using Microsoft.EntityFrameworkCore;

namespace blog_be.Model
{
    [Keyless]
    public class USER
    {
        public int  UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
