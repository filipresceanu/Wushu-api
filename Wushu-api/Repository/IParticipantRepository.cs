using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IParticipantRepository
    {
        Task AddParticipantsInCompetition(Guid competitionId, ParticipantDto participant);

        Task<IEnumerable<ParticipantDto>> GetParticipantsForCompetitionId(Guid competitionId);

        Task<IEnumerable<Participant>> GetParticipantsDataForCompetitionId(Guid competitionId);

        //TODO edit participant
        //TODO delete participant
    }
}
