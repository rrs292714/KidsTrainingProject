using System;
using System.Collections.Generic;

namespace KidsGaming.Models
{
    public partial class Game
    {
        public Game()
        {
            BuyGames = new HashSet<BuyGame>();
        }

        public int GameId { get; set; }
        public string? GameName { get; set; }
        public int? GamePrice { get; set; }

        public virtual ICollection<BuyGame> BuyGames { get; set; }
    }
}
