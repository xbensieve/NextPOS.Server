using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs.Password
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}
