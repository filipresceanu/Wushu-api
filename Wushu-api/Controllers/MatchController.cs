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

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPut("add-participants-in-match")]
        public async Task<ActionResult> AddParticipantsInMatch(Guid categoryId,Guid competitionId)
        {
            var participants=await _matchService.AddParticipantsInMatch(categoryId, competitionId);
            return Ok("success");
        }
    }
}
