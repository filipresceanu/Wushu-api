using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface IParticipantService
    {
        Task<string> AddParticipantsInCompetition(Guid competitionId, ParticipantDto participantDto);

        Task<IEnumerable<ParticipantDto>> GetParticipantsInCompetitionId(Guid competitionId);

        Task<IEnumerable<Participant>> GetParticipantsDataInCompetitionId(Guid competiton);

        Task<IEnumerable<Participant>> GetParticipantsRandomCategoyAndCompetition(Guid categoryId, Guid competitionId);

        IEnumerable<Participant> ShufflingParticipants(IEnumerable<Participant> participants);
        Task DeleteParticipant(Guid id);
    }
}
