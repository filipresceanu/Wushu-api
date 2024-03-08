using WushuParticipants.Models;

namespace WushuParticipants.Repository
{
    public interface IMatchRepository
    {
        Task AddParticipantsInMatch(Participant participantFirst,Participant participantSecond);
    }
}
