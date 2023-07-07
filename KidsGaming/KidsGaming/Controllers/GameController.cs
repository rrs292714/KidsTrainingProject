using KidsGaming.DTO;
using KidsGaming.Interface;
using KidsGaming.Models;
using KidsGaming.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KidsGaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : GenericController<Game>
    {
        private readonly Random _random = new Random();
        private readonly KidsGamingContext _context;
        private readonly EmailService _email;
    
        public GameController(KidsGamingContext context, EmailService email ,IGeneric<Game> igenric) : base(igenric)
        {
            _context=context;
            _email=email;
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> editgame(Game game)
        {
            var gameId = game.GameId;
            var data = _context.Games.FirstOrDefault(x => x.GameId == gameId);
            data.GameName=game.GameName;
            data.GamePrice=game.GamePrice;
            await _context.SaveChangesAsync();
            return Ok(_context.Games);
        }

        [HttpPut("membership")]
        public IActionResult PurchaseMembership(UserInfo user)
        {
            var data = _context.UserInfos.Find(user.UserId);
            data.Membership = 2;
            int Mem = 200;

            var mem =new MemberShip {UserId=user.UserId,Status=Mem};
            _context.Add(mem);
            _context.SaveChanges();
            return Ok("Membership purchased successfully.");
        }

        [HttpPost("Buy")]
        public IActionResult Buy(BuyDto buyDto)
        {
            var data = _context.BuyGames;
            var game = new BuyGame { GameId = buyDto.GameId, UserId = buyDto.UserId, Quantity = buyDto.Quantity };
            _context.Add(game);
            _context.SaveChanges();
            return Ok(game);
        }

        [HttpPut("Play")]
        public IActionResult Play(MemberShip member)
        {
            var userid=member.UserId;
            var data = _context.MemberShips.FirstOrDefault(x=>x.UserId==userid);
            if (data.Status == 1)
            {  
                var data1 = _context.UserInfos.FirstOrDefault(x => x.UserId == userid);
                data1.Membership = 1;
                _context.MemberShips.Remove(data);
                _context.SaveChanges();
                return Ok(_context.UserInfos);
            }
            else
            {
                data.Status = data.Status - 1;
                //var mem = new MemberShip {UserId=member.UserId,Status=member.Status-1};
                _context.SaveChanges();
                return Ok(_context.MemberShips);
            }
            
        }

        [HttpGet("Otp/{email}")]
        public IActionResult OtpGenerator(string email)
        {
            var otp = RandomNumber(1000, 9999);
            var r =email ;
            var s = "Payment Confirmation";
            var b = $"Otp:{otp}";
            _email.SendEmail(r, s, b);
            var resp = new
            {
                message = $"Email sent to {r}"
            };
            return Ok(otp);
        }
        private int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}