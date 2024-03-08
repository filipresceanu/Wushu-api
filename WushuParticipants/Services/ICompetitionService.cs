using WushuParticipants.Dto;
using WushuParticipants.Models;

namespace WushuParticipants.Services
{
    public interface ICompetitionService
    {
        Task CreateCompetition(Competition competition);

        Task<IEnumerable<CompetitionDto>> GetCompetitions(); 

        Task<Competition>GetCompetitionById(Guid id);
    }
}
