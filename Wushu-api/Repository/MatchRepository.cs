using Wushu_api.Data;

namespace Wushu_api.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly DataContext _dataContext;

        public MatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task AddParticipantsInMatch()
        {
            throw new NotImplementedException();
        }
    }
}
