using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface IParticipantService
    {
        Task AddParticipantsInCompetition(Guid competitionId, ParticipantDto participantDto);

        Task<IEnumerable<ParticipantDto>> GetParticipantsInCompetitionId(Guid competiton);

        Task<IEnumerable<Participant>> GetParticipantsDataInCompetitionId(Guid competiton);

        Task<IEnumerable<Participant>> GetParticipantsShufflingForCategoyCompetition(Guid categoryId, Guid competitionId);

        Task DeleteParticipant(Guid id);
    }
}
