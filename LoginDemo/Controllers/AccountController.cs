using LoginDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // UserManager DI takes care of all the login methods
    public class AccountController(UserManager<IdentityUser> userManager) : ControllerBase
    {
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp (SignUpModel model)
        {

            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                // Save User to DB
                // CreateAsync is for adding user to Db
                user = new IdentityUser()
                {
                    UserName = model.UserName,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Ok($"User {user.UserName} Created");
                }
                //return Ok("User Not Found");
                else
                {
                    return BadRequest("Error in adding User");
                }
            }
            else 
            {
                return BadRequest("User already found"); 
            }   
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(SignUpModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return BadRequest("User Not Found");
            }
            var result = await userManager.CheckPasswordAsync(user, model.Password);
            if (result == true)
            {
                return Ok("User Login");
            }
            else
            {
                return BadRequest("Wrong Password");
            }

            return null;
        }
    }
}
