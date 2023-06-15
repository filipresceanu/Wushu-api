using Wushu_api.Data;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly DataContext _dataContext;

        public MatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddMatch(Match match)
        {
            _dataContext.Matches.Add(match);
            await _dataContext.SaveChangesAsync();
        }
    }
}
