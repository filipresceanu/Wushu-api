using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using Wushu_api.Dto;
using Wushu_api.Helper;
using Wushu_api.Models;
using Wushu_api.Repository;


namespace Wushu_api.Services
{
    public class MatchService : IMatchService
    {
        private const int FirstRound = 0;
        private const int SecondRound = 1;
        private const int RoundNumber = 2;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IParticipantService _participantService;
        private readonly IRoundRepository _roundRepository;
        private readonly IUserRepository _userRepository;

        public MatchService(ICategoryRepository categoryRepository,
            IParticipantRepository participantRepository, IMatchRepository matchRepository,
            IParticipantService participantService, IRoundRepository roundRepository, IUserRepository userRepository)
        {

            _categoryRepository = categoryRepository;
            _participantRepository = participantRepository;
            _matchRepository = matchRepository;
            _participantService = participantService;
            _roundRepository = roundRepository;
            _userRepository = userRepository;
        }
        private async Task AddRoundInMatches(Match match)
        {
            for (int i = 0; i < RoundNumber; i++)
            {
                Round round = new Round();
                round.Match = match;
                await _roundRepository.AddRound(round);
            }
        }

        private async Task<int> AddParticipantsInMatches(IEnumerable<Participant> participants)
        {
            int latest = 0;
            int numberParticipants = participants.Count();
            if (numberParticipants % 2 == 0)
            {
                for (int index = 0; index < numberParticipants; index++)
                {
                    Match match = new Match();
                    match.CompetitorFirst = participants.ElementAt(index);
                    index++;
                    match.CompetitorSecond = participants.ElementAt(index);
                    await _matchRepository.AddMatch(match);
                    await AddRoundInMatches(match);
                    latest = index;
                }
            }
            return latest;
        }

        public async Task<IEnumerable<Match>> GetMatchesForCategory(Guid categoryId)
        {
            var matches = await _matchRepository.GetMatchesCategory(categoryId);
            return matches;
        }

        public async Task GenerateMatches(Guid eventId)
        {
            int latest = 0;
            var categories = await _categoryRepository.GetCategorieForEventId(eventId);
            foreach (var category in categories)
            {

                var participants = await _participantRepository.GetParticipantsForCategoryAndCompetition(category.Id, eventId);
                int participantsNumber = await _participantRepository.GetParticipantNumberForCategoryAndCompetition(category.Id, eventId);
                int totalNumberOfMatches = participantsNumber - 1;//this is the formula to calculate the total number of matches
                int numberOfPlayedMatches = await _matchRepository.MatchesPlayed(category.Id);
                if (totalNumberOfMatches > 0)
                {
                    if (totalNumberOfMatches - numberOfPlayedMatches > 0 && numberOfPlayedMatches > 0)
                    {
                        if (latest == 1)
                        {
                            break;
                        }
                        var winners = await GetLatestWinners(latest, category.Id);
                        latest = await AddParticipantsInMatches(winners);

                    }
                    if (numberOfPlayedMatches == 0)
                    {
                        latest = await AddParticipantsInMatches(participants);
                    }
                }

            }
        }
        private async Task<Participant> GetWinnerCategory(Guid categoryId)
        {
            var winners = await _matchRepository.GetWinnersMatches(categoryId);
            var winner = winners.FirstOrDefault();
            return winner;
        }
        private async Task<IEnumerable<Participant>> GetLatestWinners(int latest, Guid categoryId)
        {
            var winners = await _matchRepository.GetWinnersMatches(categoryId);
            var winnersLatest = new List<Participant>();

            for (int index = winners.Count() - 1; index >= latest; index--)
            {
                var winner = winners.ElementAt(index);
                winnersLatest.Add(winner);
            }
            return winnersLatest;
        }
        public async Task DistributeReferee(Guid eventId)
        {
            var categories = await _categoryRepository.GetCategorieForEventId(eventId);
            var referee = await _userRepository.GetAllUsers();
            foreach (var category in categories)
            {
                var matches = await _matchRepository.GetMatchesNoWinnerAndNoUser(category.Id);
                if (matches.Count() == referee.Count())
                {
                    int indexStart = 0;
                    await RefereesEqualMatches(matches, referee,indexStart);
                }
                if (matches.Count() > referee.Count())
                {
                    await MatchesGraterReferee(matches, referee);
                }
                if (matches.Count() < referee.Count())
                {
                    int indexStart = 0;
                    await RefereesEqualMatches(matches, referee, indexStart);
                }
            }
        }

        private async Task RefereesEqualMatches(IEnumerable<Match> matches, IEnumerable<User> users,int indexStartMatch)
        {
            int indexUser = 0;
            for (int indexMatch = indexStartMatch; indexMatch < matches.Count(); indexMatch++)
            {
                
                Match match = matches.ElementAt(indexMatch);
                User user = users.ElementAt(indexUser);
                await _matchRepository.AddRefereeInMatch(user.Id, match.Id);
                indexUser++;
            }
        }
        private async Task MatchesGraterReferee(IEnumerable<Match> matches, IEnumerable<User> users)
        {
            int refereeCount=users.Count();
            int matchesCount=matches.Count();
            int indexMatch = 0;
            int indexReferee = 0;

            while (matchesCount > refereeCount)
            {
                Match match = matches.ElementAt(indexMatch);
                User user = users.ElementAt(indexReferee);
                await _matchRepository.AddRefereeInMatch(user.Id, match.Id);
                if(indexReferee != refereeCount-1 ) 
                {
                    indexReferee++;
                }
                else
                {
                    indexReferee = 0;
                }

                
                indexMatch++;
                matchesCount--;

            }
            if (matchesCount == refereeCount)
            {
                await RefereesEqualMatches(matches, users, matchesCount);
                
            }
        }

        public async Task SetWinnerMatch(Guid matchId,[Optional]Guid winnerId)
        {
            var rounds=await _roundRepository.GetRoundsFromMatch(matchId);
            var firstRoundWinner = rounds.ElementAt(FirstRound).ParticipantWinnerId;
            var secondRoundWinner=rounds.ElementAt(SecondRound).ParticipantWinnerId;

            if (firstRoundWinner==secondRoundWinner)
            {
                await _matchRepository.SetWinnerMatch(matchId, (Guid)firstRoundWinner);
            }
            if(secondRoundWinner!=firstRoundWinner)
            {
                await _matchRepository.SetWinnerMatch(matchId, winnerId);
            }

        }

        public async Task<ParticipantDto> GetParticipantWinner(Guid matchId)
        {
            var winnerId=await _matchRepository.GetWinnerMatch(matchId);
            var participantDto=await _participantRepository.GetParticipantDto(winnerId);
            return participantDto;
        }

    }
}
