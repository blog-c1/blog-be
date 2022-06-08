using Microsoft.EntityFrameworkCore;

namespace blog_be.Model
{
    [Keyless]
    public class USER
    {
        public int  userid { get; set; }

        public string username { get; set; }

        public string email { get; set; }
    }
}
