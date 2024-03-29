﻿using System.ComponentModel.DataAnnotations;

namespace GuiEksamen.Models.Entities
{
    public class EfAccount
    {
        [Key]
        [MaxLength(254)]
        public string Email { get; set; }
        [MaxLength(60)]
        public string PwHash { get; set; }        
        public bool IsManager { get; set; }
    }
}
