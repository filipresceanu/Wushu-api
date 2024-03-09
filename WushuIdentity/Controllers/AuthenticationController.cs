using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.CompilerServices;
using WushuIdentity.Configurations;
using WushuIdentity.Data;
using WushuIdentity.DTOs;
using WushuIdentity.Helper;
using WushuIdentity.Models;

namespace WushuIdentity.Controllers
{
    [Route("api/[controller]")] // api/authentication
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityHelper _identityHelper;
        private readonly JwtConfig _jwtConfig;

        public AuthenticationController(UserManager<IdentityUser> userManager, IdentityHelper identityHelper, IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _identityHelper = identityHelper;
            _jwtConfig = jwtConfig.Value;
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
                    var jwtSecret = _jwtConfig.Secret;
                    var jwtExpire = _jwtConfig.ExpirationTime.ToString();
                    var jwtToken = await _identityHelper.GenerateJwtToken(newUser, jwtSecret, jwtExpire);
                    return Ok(jwtToken);
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
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
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

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, loginRequest.Password);

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
                var jwtSecret = _jwtConfig.Secret;
                var jwtExpire = _jwtConfig.ExpirationTime.ToString();
                var jwtToken = await _identityHelper.GenerateJwtToken(existingUser, jwtSecret, jwtExpire);
                return Ok(jwtToken);

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

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                var result = _identityHelper.VerifyAndGenerateToken(tokenRequest);

                if (result == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid parameters"
                        },
                        Result = false
                    });
                }

                return Ok(result);
            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                {
                    "Invalid parameters"
                },
                Result = false
            });
        }







    }

}
