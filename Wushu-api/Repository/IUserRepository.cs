using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
