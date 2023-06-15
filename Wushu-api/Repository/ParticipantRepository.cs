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
    
        public ParticipantRepository(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = context;
           
        }

        public async Task AddParticipantsInCompetition(Guid competitionId, Participant participant)
        {
            
            _dataContext.Participants.Add(participant);
            await SaveParticipant();

        }

        public async Task<IEnumerable<Participant>> GetParticipantsDataForCompetitionId(Guid competitionId)
        {
           
            var participants=await _dataContext.Participants.Where(elem => elem.Event.Id == competitionId).ToListAsync();
            return participants;
        }

        public async Task<IEnumerable<Participant>> GetParticipantsForCategoryAndCompetition(Guid categoryId, Guid competitionId)
        {
            try { 
            var participants = await _dataContext.Participants.Where(participant=>participant.Category.Id==categoryId && participant.Event.Id== competitionId).ToListAsync();
            return  participants;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ParticipantDto>> GetParticipantsForCompetitionId(Guid competitionId)
        {
          
            var participants =  _dataContext.Participants.Where(elem => elem.Event.Id == competitionId)
                .ProjectTo<ParticipantDto>(_mapper.ConfigurationProvider).ToListAsync();
                
            return await participants;
            
        }

        public async Task SaveParticipant()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
