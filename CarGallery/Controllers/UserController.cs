using System.Security.Claims;
using Application.Command.User;
using Application.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region InjectServices
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        #endregion




        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserCommand registerUserCommand)
        {
            if (ModelState.IsValid)
            {
               var Resualt=await  _service.RegisterAsync(registerUserCommand);
               return Ok(Resualt);
            }

            return BadRequest();
        }



        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserCommand loginUserCommand)
        {
            if (ModelState.IsValid)
            {
                var State =await _service.LoginAsync(loginUserCommand);
                if (State ==StateOfLogin.Failed)
                    return BadRequest("Something Went Wrong");
                else
                {
                    var UserId =  _service.GetUserIdByEmail(loginUserCommand.Email);
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, UserId.Id.ToString()),
                        new Claim(ClaimTypes.Email, loginUserCommand.Email),
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    return Ok("Login Success");
                }

                
            }

            return NotFound();
        }


    }
}
 