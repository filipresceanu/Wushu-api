namespace Wushu_api.Services
{
    public interface IMatchService
    {
        Task HandleParticipantsNumber(Guid competitionId);
    }
}
