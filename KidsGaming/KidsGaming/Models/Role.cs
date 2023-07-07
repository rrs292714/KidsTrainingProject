using System;
using System.Collections.Generic;

namespace KidsGaming.Models
{
    public partial class Role
    {
        public Role()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
