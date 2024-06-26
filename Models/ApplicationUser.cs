﻿using Microsoft.AspNetCore.Identity;

namespace Custom_User_Management.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }

        public int UsernameChangeLimit { get; set; } = 10;
    }
}
