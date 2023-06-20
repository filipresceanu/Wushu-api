using Wushu_api.Data;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class RoundRepository : IRoundRepository
    {
        private readonly DataContext _dataContext;

        public RoundRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddRound(Round round)
        {
             _dataContext.Rounds.Add(round);
            await _dataContext.SaveChangesAsync();
        }
    }
}
