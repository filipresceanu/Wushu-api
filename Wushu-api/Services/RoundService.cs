using Wushu_api.Dto;
using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IParticipantRepository _participantRepository;

        public RoundService(IRoundRepository roundRepository, IMatchRepository matchRepository, IParticipantRepository participantRepository)
        {
            _roundRepository = roundRepository;
            _matchRepository = matchRepository;
            _participantRepository = participantRepository;
        }

        public async Task<List<MatchRoundDto>> GetMatchesReferee(string referee)
        {
            var matches = await _matchRepository.GetMatchReferee(referee);
            int matchNumber = 1;
            List<MatchRoundDto>matchRoundDtos = new List<MatchRoundDto>();
            foreach (var match in matches)
            {
                var rounds = await _roundRepository.GetRoundsFromMatch(match.Id);
                List<RoundRefereDto>roundsDto=new List<RoundRefereDto>();

                int roundNumber = 1;
                foreach(var round in rounds)
                {

                    RoundRefereDto roundDto = new RoundRefereDto()
                    {
                        RoundNumber = roundNumber,
                        RoundId=round.Id,
                        FirstParticipantName = await _participantRepository.GetParticipantName(match.CompetitorFirstId),
                        SecondParticipantName = await _participantRepository.GetParticipantName(match.CompetitorSecondId),
                        FirstParticipantPoints = round.PointParticipantFirst,
                        SecondParticipantPoints = round.PointParticipantSecond
                    };
                    roundNumber++;
                    roundsDto.Add(roundDto);
                   

                }
                MatchRoundDto matchRoundDto = new MatchRoundDto()
                {
                    MatchNumber = matchNumber,
                    MatchId = match.Id,
                    RoundsRefere=roundsDto

                };
                matchNumber++;
                matchRoundDtos.Add(matchRoundDto);  
            }
            return matchRoundDtos;
        }

        public async Task AddPointsInRound(Guid roundId,int pointParticipantFirst,int pointParticipantSecond,Guid matchId)
        {
            await _roundRepository.AddPointsInRound(roundId, pointParticipantFirst, pointParticipantSecond);
            if(pointParticipantSecond>pointParticipantFirst)
            {
                Guid winnerId=await _matchRepository.GetSecondParticipant(matchId);
                await _roundRepository.SetWinnerRound(roundId, winnerId);
            }
            if(pointParticipantFirst>pointParticipantSecond)
            {
                Guid winnerId = await _matchRepository.GetFirstParticipant(matchId);
                await _roundRepository.SetWinnerRound(roundId, winnerId);
            }
        }

        public async Task<ParticipantDto>GetWinnerRound(Guid roundId)
        {
            var winnerId=await _roundRepository.GetWinnerIdRound(roundId);
            var participant = await _participantRepository.GetParticipantDto(winnerId);
            return participant;
        }

        
    }

}  


