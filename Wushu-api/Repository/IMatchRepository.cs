using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IMatchRepository
    {
        Task AddMatch(Match match);

        Task<IEnumerable<Match>> GetAllMatches();

        Task<IEnumerable<Match>> GetMatchesCategory(Guid categoryId);
        Task<int> MatchesPlayed(Guid categoryId);

        Task<IEnumerable<Participant>> GetWinnersMatches(Guid categoryId);

        Task<IEnumerable<Match>> GetMatchesWithParticipants(IEnumerable<Participant> participants);

        Task<IEnumerable<Match>> GetMatchesNoWinner();

        Task<IEnumerable<Match>> GetMatchesNoWinnerAndNoUser(Guid categoryId);

        Task AddRefereeInMatch(string userId, Guid matchId);
        Task<IEnumerable<Match>> GetMatchReferee(string referee);

        Task<Guid> GetSecondParticipant(Guid matchId);

        Task<Guid> GetFirstParticipant(Guid matchId);

        Task SetWinnerMatch(Guid matchId, Guid winnerId);

        Task<Guid> GetWinnerMatch(Guid matchId);

    }
}
