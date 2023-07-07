using Microsoft.EntityFrameworkCore;

namespace KidsGaming.DTO
{
    [Keyless]
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
