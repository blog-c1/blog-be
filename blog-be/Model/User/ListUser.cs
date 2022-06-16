using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_be.Model.User
{
    [Table("user") ]
    [Keyless]
    public class ListUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } 
    }
}
