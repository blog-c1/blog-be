using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace blog_be.Model.Login
{
    [Keyless]
    public partial class UserLoginInfo
    {
        [Column("user_name")]
        public string UserName { get; set; }

        [NotMapped]
        public string Pwd { get; set; }

        [Column("role")]
        public string Role { get; set; }
    }
}
