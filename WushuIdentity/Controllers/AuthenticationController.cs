using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WushuIdentity.Configurations;
using WushuIdentity.DTOs;
using WushuIdentity.Models;

namespace WushuIdentity.Controllers
{
    [Route("api/[controller]")] // api/authentication
    [ApiController]
    public class AuthenticationController:ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthenticationController(JwtConfig jwtConfig, UserManager<IdentityUser> userManager)
        {
            _jwtConfig = jwtConfig;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            // Validate the incoming request
            if (ModelState.IsValid)
            {
                //We need to check if the email already exist
                var userExist = await _userManager.FindByEmailAsync(requestDto.Email);

                if (userExist != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email already exist"
                        }
                    });
                }

                //create a user
                var newUser = new IdentityUser()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.Email
                };

                var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

                if (isCreated.Succeeded)
                {
                    // Generate the token
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Server error"
                    },
                    Result = false
                });
            }

            return BadRequest();
        }









    }
}
