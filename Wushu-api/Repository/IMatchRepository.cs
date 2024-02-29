using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IMatchRepository
    {
        Task AddParticipantsInMatch(Participant participantFirst,Participant participantSecond);
    }
}
