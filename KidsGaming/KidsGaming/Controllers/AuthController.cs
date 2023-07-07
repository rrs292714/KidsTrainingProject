using KidsGaming.DTO;
using KidsGaming.Interface;
using KidsGaming.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace KidsGaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly KidsGamingContext _context;
        private readonly IConfiguration _config;
        private readonly IHash _hash;

        public AuthController(KidsGamingContext context, IConfiguration config, IHash hash)
        {
            _context = context;
            _config = config;
            _hash = hash;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(Register registerDto)
        {
            if (registerDto.Email == null)
            {
                return BadRequest("ENTER A EMAIL");
            }

            if (_context.UserInfos.Any(x => x.Email == registerDto.Email))
            {
                return BadRequest("User already Exist!");
            }

            var hmac = new HMACSHA256();
            string salt = Convert.ToBase64String(hmac.Key);
            registerDto.Password = _hash.Hash(registerDto.Password, salt);
            int roleId = 2;
            int membership = 1;
            var user = new UserInfo { FullName = registerDto.FullName,Membership=membership, Email = registerDto.Email, PasswordHash = registerDto.Password, PasswordSalt = salt, RoleId = roleId };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(Login login)
        {
            var user = (from u in _context.UserInfos
                        join r in _context.Roles on u.RoleId equals r.RoleId
                        select new
                        {
                            Id = u.UserId,
                            FullName=u.FullName,
                            Email = u.Email,
                            PasswordHash = u.PasswordHash,
                            PasswordSalt = u.PasswordSalt,
                            MemberShip=u.Membership,
                            Role = r.RoleName
                        }).FirstOrDefault(user => user.Email == login.Email);

            if (user == null)
            {
                return BadRequest("User not Found");
            }

            if (!_hash.verify(login.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            UserDto usr = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PaasswordSalt = user.PasswordSalt,
                Role = user.Role,
                Membership=user.MemberShip
            };
            var tkn = tokengenrator(usr);
            return Ok(new { token = tkn,Id=user.Id,Email=user.Email, FullName = user.FullName,Membership=user.MemberShip, role = user.Role, message = "user logged in" });

        }
        private object tokengenrator(UserDto usr)
        {
            var sectret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:key").Value));
            var crad = new SigningCredentials(sectret, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.SerialNumber,usr.Id.ToString()),
                new Claim(
                    ClaimTypes.Role,usr.Role),
                new Claim(
                    ClaimTypes.Email,usr.Email),
            };
            var tk = new JwtSecurityToken(
                _config.GetSection("Jwt:Issuer").Value,
                _config.GetSection("Jwt:Audience").Value,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: crad,
                claims: claims
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tk);
            return Ok(token);
        }
    }
}
