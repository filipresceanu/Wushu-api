using AutoMapper;
using AutoMapper.QueryableExtensions;
using Wushu_api.Dto;
using Wushu_api.Helper;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class MatchService : IMatchService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;


        public MatchService(IMapper mapper, ICategoryRepository categoryRepository, IParticipantRepository participantRepository)
        {

            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _participantRepository = participantRepository;
        }

        

        public async Task<IEnumerable<Participant>>  AddParticipantsInMatch(Guid categoryId, Guid competitionId)
        {
            var participants= await _participantRepository.GetParticipantsForCategoryAndCompetition(categoryId, competitionId);
            return participants;
            
        }
    }
}
