using AutoMapper;
using AutoMapper.QueryableExtensions;
using Wushu_api.Data;
using Wushu_api.Dto;
using Wushu_api.Models;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Wushu_api.Repository
{
    public class ParticipantRepository:IParticipantRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IEventRepository _eventRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ParticipantRepository(DataContext context,IMapper mapper,IEventRepository eventRepository,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _dataContext = context;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddParticipantsInCompetition(Guid competitionId, ParticipantDto participantDto)
        {
            var categories = await _categoryRepository.GetAllCategories();
            var competition=await _eventRepository.GetEventId(competitionId);
            var participant = _mapper.Map<Participant>(participantDto);

            foreach(var category in categories)
            {
                if(category.Sex==participant.Sex && participant.CategoryWeight==category.Weight &&(participant.calculateAge(participant.BirthDay)>=category.GraterThanAge && participant.calculateAge(participant.BirthDay) <= category.LessThanAge))
                {
                    participant.Event = competition;
                    participant.Category = category;
                    _dataContext.Participants.Add(participant);
                    competition.Participants.Add(participant);

                }

            }

            await _dataContext.SaveChangesAsync();
            

        }

        public async Task<IEnumerable<Participant>> GetParticipantsDataForCompetitionId(Guid competitionId)
        {
            Event competion = await _eventRepository.GetEventId(competitionId);
            var participants=await _dataContext.Participants.Where(elem => elem.Event == competion).ToListAsync();
            return participants;
        }

        public async Task<IEnumerable<ParticipantDto>> GetParticipantsForCompetitionId(Guid competitionId)
        {
            Event competion=await _eventRepository.GetEventId(competitionId);
            var participants =  _dataContext.Participants.Where(elem => elem.Event == competion)
                .ProjectTo<ParticipantDto>(_mapper.ConfigurationProvider).ToListAsync();
                
            return await participants;
            
        }
    }
}
