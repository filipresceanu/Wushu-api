namespace WushuParticipants.Services
{
    public interface IMatchService
    {
        Task HandleParticipantsNumber(Guid competitionId);
    }
}
