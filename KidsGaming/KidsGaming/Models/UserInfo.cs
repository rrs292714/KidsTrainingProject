using System;
using System.Collections.Generic;

namespace KidsGaming.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            BuyGames = new HashSet<BuyGame>();
            MemberShips = new HashSet<MemberShip>();
        }
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public int? RoleId { get; set; }
        public int? Membership { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<BuyGame> BuyGames { get; set; }
        public virtual ICollection<MemberShip> MemberShips { get; set; }
    }
}
