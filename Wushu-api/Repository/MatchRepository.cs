using Microsoft.EntityFrameworkCore;
using Wushu_api.Data;
using Wushu_api.Dto;
using Wushu_api.Models;

namespace Wushu_api.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly DataContext _dataContext;

        public MatchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddMatch(Match match)
        {
            _dataContext.Matches.Add(match);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddRefereeInMatch(string userID, Guid matchId)
        {
            var match = await _dataContext.Matches.Where(element => element.Id == matchId).SingleOrDefaultAsync();
            match.UserId = userID;
            await _dataContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Match>> GetAllMatches()
        {
            var matches = await _dataContext.Matches.ToListAsync();
            return matches;
        }

        public async Task<IEnumerable<Match>> GetMatchesCategory(Guid categoryId)
        {
            var matches = await _dataContext.Matches.Where(element => element.CompetitorFirst.CategoryId == categoryId).ToListAsync();
            return matches;
        }

        public async Task<int> MatchesPlayed(Guid categoryId)
        {
            var matches = await _dataContext.Matches.Where(element => element.CompetitorFirst.CategoryId == categoryId && element.ParticipantWinnerId != null).ToListAsync();
            return matches.Count();
        }

        public async Task<IEnumerable<Participant>> GetWinnersMatches(Guid categoryId)
        {
            var playedMatches = await _dataContext.Matches.Where(element => element.CompetitorFirst.CategoryId == categoryId && element.ParticipantWinnerId != null).ToListAsync();
            var winners = new List<Participant>();
            foreach (var match in playedMatches)
            {
                var winner = await _dataContext.Participants.Where(element => element.Id == match.ParticipantWinnerId).SingleOrDefaultAsync();
                winners.Add(winner);

            }
            return winners;
        }

        public async Task<IEnumerable<Match>> GetMatchesWithParticipants(IEnumerable<Participant> participants)
        {
            var matches = new List<Match>();
            foreach (var participant in participants)
            {
                var match = await _dataContext.Matches.Where(element => element.CompetitorFirstId == participant.Id && element.ParticipantWinnerId == null).SingleOrDefaultAsync();
                if (match != null)
                {
                    matches.Add(match);

                }
            }
            return matches;
        }

        public async Task<IEnumerable<Match>> GetMatchesNoWinnerAndNoUser(Guid categoryId)
        {
            var matches = await _dataContext.Matches.Where(element => element.UserId == null && element.ParticipantWinnerId == null && element.CompetitorFirst.CategoryId == categoryId).ToListAsync();
            return matches;
        }

        public async Task<IEnumerable<Match>> GetMatchesNoWinner()
        {
            var matches = await _dataContext.Matches.Where(element => element.ParticipantWinnerId == null ).ToListAsync();
            return matches;
        }

        public async Task<IEnumerable<Match>> GetMatchReferee(string referee)
        {
            var matches = await _dataContext.Matches.Where(element => element.UserId == referee).ToListAsync();
            return matches;

        }

        public async Task<Guid>GetFirstParticipant(Guid matchId)
        {
            var match = await _dataContext.Matches.Where(element => element.Id == matchId).FirstOrDefaultAsync();
            return match.CompetitorFirstId;
        }

        public async Task<Guid> GetSecondParticipant(Guid matchId)
        {
            var match = await _dataContext.Matches.Where(element => element.Id == matchId).FirstOrDefaultAsync();
            return match.CompetitorSecondId;
        }

        public async Task SetWinnerMatch(Guid matchId,Guid winnerId)
        {
            var match = await _dataContext.Matches.Where(element => element.Id == matchId).FirstOrDefaultAsync();
            match.ParticipantWinnerId=winnerId;
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Guid>GetWinnerMatch(Guid matchId)
        {
            var match=await _dataContext.Matches.Where(element=>element.ParticipantWinnerId!=null && element.Id==matchId).FirstOrDefaultAsync();
            return (Guid)match.ParticipantWinnerId;

        }
    }
}
