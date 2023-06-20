using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wushu_api.Services;

namespace Wushu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMatchDistributionService _matchDistributionService;

        public MatchController(IMatchService matchService, IMatchDistributionService matchDistributionService)
        {
            _matchService = matchService;
            _matchDistributionService = matchDistributionService;
        }

        [HttpPut("add-participants-in-match")]
        public async Task<ActionResult> AddParticipantsInMatch(Guid categoryId,Guid competitionId)
        {
            var participants=await _matchService.AddParticipantsInMatch(categoryId, competitionId);
            return Ok("success");
        }
        [HttpPut("add-rounds-in-match")]
        public async Task<ActionResult> AddRoundInMatches()
        {
            try
            {
                await _matchService.AddRoundInMatches();
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest("something bad happens");
            }
        }

        [HttpPut("add-match-in-distribution")]
        public async Task<ActionResult> AddInMatchDistribution(Guid competitionId)
        {
            try
            {
                await _matchDistributionService.AddMatchInMatchDistribution(competitionId);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest("something bad happens");
            }
        }
    }
}
