using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Wushu_api.Data;
using Wushu_api.Models;

namespace Wushu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult>Register(UserRegisterRequest request)
        //{
        //    if(_context.Users.Any(u=>u.Email==request.Email))
        //    {
        //        return BadRequest("User already exists");
        //    }

        //    CreatePasswordHash(request Password, out byte[] passwordHash,out byte[] passordSalt);
        //}

        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passordSalt)
        //{
        //    using( var hmac =new HMACSHA512())
        //    {
        //        passordSalt=ham
        //    }
        //}
    }
}
