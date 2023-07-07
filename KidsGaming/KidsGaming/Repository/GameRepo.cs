using KidsGaming.Interface;
using KidsGaming.Models;

namespace KidsGaming.Repository
{
    public class GameRepo : IGeneric<Game>
    {
        private readonly KidsGamingContext _context;


        public GameRepo(KidsGamingContext context)
        {
            _context = context;
        }

        List<Game> IGeneric<Game>.delete(int id)
        {
            var games = _context.Games.FirstOrDefault(x => x.GameId == id);
        
            _context.Games.Remove(games);
            _context.SaveChanges();
            return _context.Games.ToList();
        }

        List<Game> IGeneric<Game>.getall()
        {
           var products = (from x in _context.Games  select x).ToList();
          return products;
        }

        List<Game> IGeneric<Game>.getbyId(int id)
        {
            var games = (from x in _context.Games where x.GameId == id select x).ToList();
            return games;
        }

        List<Game> IGeneric<Game>.Insert(Game item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return _context.Games.ToList();
        }
    }
}
