﻿using System.ComponentModel.DataAnnotations;

namespace GuiEksamen.Models.DTOs
{
    public class User
    {
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }
        [MaxLength(254)]
        public string Email { get; set; }
        [MaxLength(60)]
        public string Password { get; set; }

        // user settings
        public int Freq { get; set; }
        public int Duration { get; set; }
    }
}
