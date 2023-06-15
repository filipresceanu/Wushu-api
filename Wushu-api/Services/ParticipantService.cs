using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class ParticipantService:IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        
        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task AddParticipantsInCompetition(Guid eventId, ParticipantDto participantDto)
        {
            await _participantRepository.AddParticipantsInCompetition(eventId, participantDto);
        }

        public async Task<IEnumerable<Participant>> GetParticipantsDataInCompetitionId(Guid competiton)
        {
            return await _participantRepository.GetParticipantsDataForCompetitionId(competiton);
        }

        public async Task<IEnumerable<ParticipantDto>> GetParticipantsInCompetitionId(Guid competiton)
        {
            return await _participantRepository.GetParticipantsForCompetitionId(competiton);
        }
    }
}
