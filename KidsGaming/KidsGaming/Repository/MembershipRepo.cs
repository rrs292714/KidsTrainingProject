using KidsGaming.Interface;
using KidsGaming.Models;

namespace KidsGaming.Repository
{
    public class MembershipRepo : IGeneric<MemberShip>
    {
        private readonly KidsGamingContext _context;


        public MembershipRepo(KidsGamingContext context)
        {
            _context = context;
        }

        List<MemberShip> IGeneric<MemberShip>.delete(int id)
        {
            var games = _context.Games.FirstOrDefault(x => x.GameId == id);

            _context.Games.Remove(games);
            _context.SaveChanges();
            return _context.MemberShips.ToList();
        }

        List<MemberShip> IGeneric<MemberShip>.getall()
        {
            var products = (from x in _context.MemberShips select x).ToList();
            return products;
        }

        List<MemberShip> IGeneric<MemberShip>.getbyId(int id)
        {
            var games = (from x in _context.MemberShips where x.UserId == id select x).ToList();
            return games;
        }

        List<MemberShip> IGeneric<MemberShip>.Insert(MemberShip item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return _context.MemberShips.ToList();
        }
    }
}
