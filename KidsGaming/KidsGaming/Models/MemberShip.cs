using System;
using System.Collections.Generic;

namespace KidsGaming.Models
{
    public partial class MemberShip
    {
        public int SubId { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }

        public virtual UserInfo? User { get; set; }
    }
}
