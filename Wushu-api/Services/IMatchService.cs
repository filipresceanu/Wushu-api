using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface IMatchService
    {
        Task<IEnumerable<Participant>> AddParticipantsInMatch(Guid categoryId,Guid competitionId);

        Task AddRoundInMatches();
    }
}
