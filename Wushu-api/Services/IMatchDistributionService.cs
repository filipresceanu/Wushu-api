namespace Wushu_api.Services
{
    public interface IMatchDistributionService
    {
        Task AddMatchInMatchDistribution(Guid eventId);
    }
}
