﻿using System.ComponentModel.DataAnnotations;

namespace GuiEksamen.Models.Entities
{
    public class EfUser
    {
        public long EfUserId { get; set; }
        public long EfAccountId { get; set; }
        public EfAccount Account { get; set; }
        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }
        [MaxLength(254)]
        public string Email { get; set; }

        // user settings
        public int Freq { get; set; }
        public int Duration { get; set; }
    }
}
