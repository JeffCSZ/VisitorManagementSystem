using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace VisitorManagementSystem.Authentication
{
    public class AddOrUpdateAppUserModel 
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string Username { get; set; } = string.Empty;
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = string.Empty;
        public string? UnitNo { get; set; }
        public string? StreetName { get; set; }
    }
}
