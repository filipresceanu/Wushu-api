using AutoMapper;
using AutoMapper.QueryableExtensions;
using Wushu_api.Dto;
using Wushu_api.Helper;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public class MatchService : IMatchService
    {
        private readonly ICategoryService _categoryService;
        private readonly IParticipantService _participantService;
        private readonly IMapper _mapper;
        

        public MatchService(ICategoryService categoryService, IParticipantService participantService,IMapper mapper)
        {
            _categoryService = categoryService;
            _participantService = participantService;
            _mapper = mapper;
           
        }

        public async Task<IEnumerable<IEnumerable<Participant>>> DistributionParticipant(Guid competitionId)
        {
           List<List<Participant>>participantsCompetiton = new List<List<Participant>>();
            var participants= await _participantService.GetParticipantsDataInCompetitionId(competitionId);
            var categories= await _categoryService.GetAllCategoriesDto();
            foreach(var category in categories)
            {
                List<Participant>participantCategory = new List<Participant>();

            }
            return null;
        }
    }
}
