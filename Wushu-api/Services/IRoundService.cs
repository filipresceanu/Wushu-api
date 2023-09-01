using Wushu_api.Dto;

namespace Wushu_api.Services
{
    public interface IRoundService
    {
        Task<List<MatchRoundDto>> GetMatchesReferee(string referee);

        Task AddPointsInRound(Guid roundId, int pointParticipantFirst, int pointParticipantSecond, Guid matchId);

        Task<ParticipantDto> GetWinnerRound(Guid roundId);
    }
}
