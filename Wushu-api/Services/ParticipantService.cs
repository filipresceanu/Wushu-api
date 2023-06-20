using AutoMapper;
using Wushu_api.Data;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class ParticipantService:IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public ParticipantService(IParticipantRepository participantRepository, ICategoryRepository categoryRepository, IEventRepository eventRepository, IMapper mapper = null)
        {
            _participantRepository = participantRepository;
            _categoryRepository = categoryRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task AddParticipantsInCompetition(Guid eventId, ParticipantDto participantDto)
        {
            var categories = await _categoryRepository.GetAllCategories();
            var competition = await _eventRepository.GetEventId(eventId);
            var participant = _mapper.Map<Participant>(participantDto);

            foreach (var category in categories)
            {
                if (category.Sex == participant.Sex && participant.CategoryWeight == category.Weight && (participant.calculateAge(participant.BirthDay) >= category.GraterThanAge && participant.calculateAge(participant.BirthDay) <= category.LessThanAge))
                {
                    participant.Event = competition;
                    participant.Category = category;
                    await _participantRepository.AddParticipantsInCompetition(eventId, participant);
                }
            }
            

        }

        public async Task<IEnumerable<Participant>> GetParticipantsDataInCompetitionId(Guid competiton)
        {
            return await _participantRepository.GetParticipantsDataForCompetitionId(competiton);
        }

        public async Task<IEnumerable<Participant>> GetParticipantsShufflingForCategoyCompetition(Guid categoryId, Guid competitionId)
        {
            var participants =await _participantRepository.GetParticipantsForCategoryAndCompetition(categoryId, competitionId);
            var participantsShuffling = participants.OrderBy(elem => Guid.NewGuid()).ToList();
            return participantsShuffling;
        }

        public async Task<IEnumerable<ParticipantDto>> GetParticipantsInCompetitionId(Guid competiton)
        {
            return await _participantRepository.GetParticipantsForCompetitionId(competiton);
        }

        public async Task DeleteParticipant(Guid id)
        {
            await _participantRepository.DeleteParticipants(id);
        }
    }
}
