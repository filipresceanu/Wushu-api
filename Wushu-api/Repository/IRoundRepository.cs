using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IRoundRepository
    {
        Task AddRound(Round round);
    }
}
