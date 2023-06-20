using Wushu_api.Models;
using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class MatchDistribuitionService : IMatchDistributionService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMatchDistributionRepository _matchDistributionRepository; 
        private readonly IEventRepository _eventRepository;

        public MatchDistribuitionService(ICategoryRepository categoryRepository, IParticipantRepository participantRepository,
            IMatchDistributionRepository matchDistributionRepository, IEventRepository eventRepository)
        {
            _categoryRepository = categoryRepository;
            _participantRepository = participantRepository;
            _matchDistributionRepository = matchDistributionRepository;
            _eventRepository = eventRepository;
        }

        public async Task AddMatchInMatchDistribution(Guid eventId)
        {
            var categories=await _categoryRepository.GetAllCategories();
            List<Category>categorywithParticipants=new List<Category>();
            foreach (var category in categories)
            {
                var participants = await _participantRepository.GetParticipantsForCategoryAndCompetition(category.Id, eventId);
                if(participants == null)
                {
                    continue;
                }
                categorywithParticipants.Add(category);
            }
           var ord= categorywithParticipants.OrderBy(element => element.GraterThanAge).ThenBy(element=>element.Sex);



          
        }
    }
}
