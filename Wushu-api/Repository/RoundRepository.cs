using Microsoft.EntityFrameworkCore;
using Wushu_api.Data;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class RoundRepository : IRoundRepository
    {
        private readonly DataContext _dataContext;

        public RoundRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddRound(Round round)
        {
             _dataContext.Rounds.Add(round);
            await _dataContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Round>> GetRoundsFromMatch(Guid matchId)
        {
            var rounds = await _dataContext.Rounds.Where(element=>element.MatchId == matchId).ToListAsync();
            return rounds;
        }

        public async Task AddPointsInRound(Guid roundId, int pointParticipantFirst, int pointParticipantSecond)
        {
            var round=await _dataContext.Rounds.Where(element=>element.Id == roundId).FirstOrDefaultAsync();
            round.PointParticipantFirst = pointParticipantFirst;
            round.PointParticipantSecond = pointParticipantSecond;
            await _dataContext.SaveChangesAsync();
        }

        public async Task SetWinnerRound(Guid roundId,Guid winnerId)
        {
            var round= await _dataContext.Rounds.Where(element=>element.Id==roundId).FirstOrDefaultAsync();
            round.ParticipantWinnerId = winnerId;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Round>GetRound(Guid roundId)
        {
            var round = await _dataContext.Rounds.Where(element => element.Id == roundId).FirstOrDefaultAsync();
            return round;
        }

        public async Task<Guid>GetWinnerIdRound(Guid roundId)
        {
            var round = await _dataContext.Rounds.Where(element => element.Id == roundId).FirstOrDefaultAsync();
            return (Guid)round.ParticipantWinnerId;
        }
    }
}
