using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using WushuIdentity.Configurations;
using WushuIdentity.DTOs;
using WushuIdentity.Helper;
using WushuIdentity.Models;

namespace WushuIdentity.Controllers
{
    [Route("api/[controller]")] // api/authentication
    [ApiController]
    public class AuthenticationController:ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityHelper _identityHelper;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, IdentityHelper identityHelper, IConfiguration configuration)
        {
            _userManager = userManager;
            _identityHelper = identityHelper;
            _configuration = configuration;
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

                //We need to check if the username already exist
                var userNameExist = await _userManager.FindByNameAsync(requestDto.Name);

                if (userNameExist != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Username already exist"
                        }
                    });
                }

                //create a user
                var newUser = new IdentityUser()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.Name
                };

                var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

                if (isCreated.Succeeded)
                {
                    // Generate the token
                    var jwtKey = _configuration.GetSection("JwtConfig:Secret").Value;
                    var token = _identityHelper.GenerateJwtToken(newUser, jwtKey);
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
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

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginRequestDto loginRequest)
        {
            if (ModelState.IsValid)
            {
                // Check if the user exist
                var existingUser = await _userManager.FindByEmailAsync(loginRequest.Email);

                if (existingUser == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid payload"
                        },
                        Result = false
                    });
                }

                var isCorrect =await _userManager.CheckPasswordAsync(existingUser, loginRequest.Password);

                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid credentials"
                        },
                        Result = false
                    });
                }
                var jwtKey = _configuration.GetSection("JwtConfig:Secret").Value;
                var jwtToken = _identityHelper.GenerateJwtToken(existingUser, jwtKey);
                return Ok(new AuthResult()
                {
                    Token = jwtToken,
                    Result = true
                });


            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid payload"
                },
                Result = false
            });

        }









    }

}
