using Wushu_api.Repository;

namespace Wushu_api.Services
{
    public class RoundService:IRoundService 
    {
        private readonly IRoundRepository _roundRepository;

        public RoundService(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;     
        }


    }
}
