using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Services
{
    public interface ICompetitionService
    {
        Task CreateCompetition(Competition competition);

        Task<IEnumerable<CompetitionDto>> GetCompetitions(); 

        Task<Competition>GetCompetitionById(Guid id);
    }
}
