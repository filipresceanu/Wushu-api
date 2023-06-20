using Wushu_api.Data;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class MatchDistributionRepository : IMatchDistributionRepository
    {
        private readonly DataContext _dataContext;

        public MatchDistributionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddMatchDistribution(MatchDistributions matchDistributions)
        {
            _dataContext.MatchDistributions.Add(matchDistributions);
            await _dataContext.SaveChangesAsync();
        }
    }
}
