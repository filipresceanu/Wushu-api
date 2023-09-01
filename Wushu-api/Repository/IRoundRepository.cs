using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IRoundRepository
    {
        Task AddRound(Round round);

        Task<IEnumerable<Round>> GetRoundsFromMatch(Guid matchId);

        Task AddPointsInRound(Guid roundId, int pointParticipantFirst, int pointParticipantSecond);

        Task SetWinnerRound(Guid roundId, Guid winnerId);

        Task<Round> GetRound(Guid roundId);

        Task<Guid> GetWinnerIdRound(Guid roundId);
    }
}
