using System;
using System.Collections.Generic;

namespace KidsGaming.Models
{
    public partial class BuyGame
    {
        public int BuyId { get; set; }
        public int? GameId { get; set; }
        public int? UserId { get; set; }
        public int? Quantity { get; set; }
        public virtual Game? Game { get; set; }
        public virtual UserInfo? User { get; set; }
    }
}
