using Microsoft.EntityFrameworkCore;

namespace KidsGaming.DTO
{
    [Keyless]
    public class Register
    {
        public string FullName {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
