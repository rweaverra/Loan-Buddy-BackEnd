﻿using System.ComponentModel.DataAnnotations;

namespace Loan_Buddy_Api.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(50)]
        public string DateCreated { get; set; } = string.Empty;
    }

}