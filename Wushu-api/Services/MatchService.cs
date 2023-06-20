using AutoMapper;
using AutoMapper.QueryableExtensions;
using Wushu_api.Dto;
using Wushu_api.Helper;
using Wushu_api.Models;
using Wushu_api.Repository;


namespace Wushu_api.Services
{
    public class MatchService : IMatchService
    {
        private const int RoundNumber = 2;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;
        private readonly IParticipantService _participantService;
        private readonly IRoundRepository _roundRepository;

        public MatchService(IMapper mapper, ICategoryRepository categoryRepository,
            IParticipantRepository participantRepository,IMatchRepository matchRepository, 
            IParticipantService participantService,IRoundRepository roundRepository)
        {

            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _participantRepository = participantRepository;
            _matchRepository = matchRepository;
            _participantService = participantService;   
            _roundRepository = roundRepository;
        }


        public async Task<IEnumerable<Participant>>  AddParticipantsInMatch(Guid categoryId, Guid competitionId)
        {
            var participants= await _participantService.GetParticipantsShufflingForCategoyCompetition(categoryId, competitionId);

            for (int index = 0; index <= participants.Count(); index++)
            {
                if (index < participants.Count())
                {
                    Match match = new Match();

                    match.CompetitorFirstId = participants.ElementAt(index).Id;
                    index++;
                    match.CompetitorSecondId = participants.ElementAt(index).Id;

                    await _matchRepository.AddMatch(match);
                }
            }


            return participants;
            
        }

        public async Task AddRoundInMatches()
        {
            var matches=await _matchRepository.GetAllMatches();
            foreach(var match in matches)
            {
                for(int i=0;i<RoundNumber;i++)
                {
                    Round round=new Round();
                    round.Match=match;
                   await _roundRepository.AddRound(round);
                   
                }
            }
        }
    }
}
