using Microsoft.AspNetCore.Mvc;
using WushuParticipants.Services;

namespace WushuParticipants.Controllers
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

        [HttpPut("add-participants-matches")]
        public async Task<ActionResult>AddParticipantsInMatches(Guid competitionId)
        {
            try
            {
                await _matchService.HandleParticipantsNumber(competitionId);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest("Someting Bad");
            }
        }
    }
}
