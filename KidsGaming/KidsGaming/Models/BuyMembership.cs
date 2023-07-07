using System;
using System.Collections.Generic;


namespace KidsGaming.Models
{
    public partial class BuyMembership
    {
        public int id { get; set; }
        public int? UserId { get; set; }
        public int? TicketCount { get; set; }
        public virtual UserInfo? User { get; set; }
    }
}