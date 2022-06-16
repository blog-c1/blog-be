namespace blog_be.Login.Model;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
public class UserLoginInfo
{
    [Column("user_name")]
    public string UserName { get; set; }

    [Column("role")]
    public string Role { get; set; }
}