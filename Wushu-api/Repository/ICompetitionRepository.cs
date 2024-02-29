using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public interface ICompetitionRepository
    {
        Task CreateCompetition(Competition competition);

        Task DeleteCompetition(Competition competition);

        Task<Competition> GetCompetitionId(Guid  competitionId);

        Task<IEnumerable<CompetitionDto>> GetCompetitions();

        //TODO edit event


    }
}
