using System.ComponentModel.DataAnnotations;

namespace Loan_Buddy_Api.DTOs
{
    public class UserDto
    {   
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
