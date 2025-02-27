using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VisitorManagementSystem.Authentication
{
    public class AppUser : IdentityUser 
    {
        [Key]
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UnitNo { get; set; }
        public string? StreetName { get; set; }

    }
}
