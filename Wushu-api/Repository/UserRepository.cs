using Microsoft.EntityFrameworkCore;
using Wushu_api.Data;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var referee=await _context.Users.ToListAsync();
            return referee;
        }
    }
}
