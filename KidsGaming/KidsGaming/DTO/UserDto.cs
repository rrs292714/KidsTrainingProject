﻿namespace KidsGaming.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PaasswordSalt { get; set; }
        public string Role { get; set; }
        public int? Membership { get; set; }

    }
}
