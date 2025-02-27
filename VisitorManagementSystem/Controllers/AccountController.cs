using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VisitorManagementSystem.Authentication;

namespace VisitorManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<AppUser> userManager, IConfiguration configuration) : ControllerBase
    {
    }

    //[HttpPost("register")]
    //public async Task<IActionResult> Register([FromBody] AddOrUpdateAppUserModel model)
    //{
    //    var user = new AppUser
    //    {
    //        UserName = model.Username,
    //        Email = model.Email,
    //        SecurityStamp = Guid.NewGuid().ToString()
    //    };
    //    return null;
    //}
}
