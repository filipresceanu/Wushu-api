using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface IParticipantRepository
    {
        Task AddParticipantsInCompetition(Participant participant);

        Task<IEnumerable<ParticipantDto>> GetParticipantsForCompetitionId(Guid competitionId);

        Task<IEnumerable<Participant>> GetParticipantsDataForCompetitionId(Guid competitionId);

        Task<IEnumerable<Participant>>GetParticipantsForCategoryAndCompetition(Guid categoryId, Guid competitionId);

        Task<IEnumerable<Participant>> GetParticipanstShuffling();

        Task DeleteParticipants(Guid participantId);

        Task<Participant> GetParticipant(Guid participantId);

        Task<string> GetParticipantName(Guid participantId);

        Task SaveParticipant();

        Task<int> GetParticipantNumberForCategoryAndCompetition(Guid categoryId, Guid competitionId);

        Task<ParticipantDto> GetParticipantDto(Guid participantId);

        //TODO edit participant
        //TODO delete participant
    }
}
