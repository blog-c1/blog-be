using System;
using System.Collections.Generic;

namespace blog_be.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
        public bool? DelFlg { get; set; }
    }
}
