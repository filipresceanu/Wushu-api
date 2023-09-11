using System.Runtime.InteropServices;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface IMatchService
    {

        Task GenerateMatches(Guid eventId);

        Task<IEnumerable<Match>>GetMatchesForCategory(Guid categoryId);

        Task DistributeReferee(Guid eventId);

       

        Task SetWinnerMatch(Guid matchId, [Optional] Guid winnerId);


        Task<ParticipantDto> GetParticipantWinner(Guid matchId);

        Task<IEnumerable<CategoryMatchDto>> GetMatchesCategory(Guid eventId);
    }
}
