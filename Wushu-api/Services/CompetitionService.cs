using AutoMapper;
using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class CompetitionService:ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionService(ICompetitionRepository competitionRepository,IMapper mapper)
        {
            _competitionRepository = competitionRepository;
        }

        public async Task CreateCompetition(Competition competition)
        {
           await _competitionRepository.CreateCompetition(competition);
        }

        public async Task<Competition> GetCompetitionById(Guid id)
        {
            var element= await _competitionRepository.GetCompetitionId(id);
            return element;
        }

        public async Task<IEnumerable<CompetitionDto>> GetCompetitions()
        {
            var events= await _competitionRepository.GetCompetitions();
            return events;
        }
    }
}
