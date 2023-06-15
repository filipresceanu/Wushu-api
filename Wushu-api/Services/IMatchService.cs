using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface IMatchService
    {
        Task<IEnumerable<IEnumerable<Participant>>> DistributionParticipant(Guid competitionId);
    }
}
