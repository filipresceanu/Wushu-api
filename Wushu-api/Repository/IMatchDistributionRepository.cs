using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IMatchDistributionRepository
    {
        Task AddMatchDistribution(MatchDistributions matchDistributions);
    }
}
