using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;
using Wushu_api.Dto;
using Wushu_api.Services;

namespace Wushu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IRoundService _roundService;

        public MatchController(IMatchService matchService, IRoundService roundService)
        {
            _matchService = matchService;
            _roundService = roundService;
        }


        [HttpPut("Generate-Matches")]
        public async Task<ActionResult>Generatematches(Guid id)
        {
            try
            {
                await _matchService.GenerateMatches(id);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest("something bad happens");
            }
        }

        [HttpPut("Distribute_Referee")]
        public async Task<ActionResult> DistributeReferee(Guid eventId)
        {
            try
            {
                await _matchService.DistributeReferee(eventId);
                return Ok("success");
            }
            catch(Exception ex)
            {
                return BadRequest("something bad happens");
            }
        }

        [HttpGet("GetMatchesReferee/{refereeId}")]
        public async Task<ActionResult<IEnumerable<MatchRoundDto>>>GetMatchesForReferee(string refereeId)
        {
            try
            {
                var matchesReferee = await _roundService.GetMatchesReferee(refereeId);
                return matchesReferee;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AddPointsRound/{roundId}")]
        public async Task<ActionResult> AddPointsInRound(Guid roundId, PointsDto points)
        {
            try
            {
                await _roundService.AddPointsInRound(roundId, points.PointsFirstParticipant,points.PointsSecondParticipant,points.MatchId);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("SetWinnerMatch/{matchId}")]
        public async Task<ActionResult>SetWinnerMatch(Guid matchId, [Optional] Guid winnerId)
        {
            try
            {
                await _matchService.SetWinnerMatch(matchId,winnerId);
                return Ok("success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("WinnerRound/{roundId}")]
        public async Task<ActionResult<ParticipantDto>>GetWinnerRound(Guid roundId)
        {
            try
            {
                var participant =await _roundService.GetWinnerRound(roundId);
                return participant;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("WinnerMatch/{matchId}")]
        public async Task<ActionResult<ParticipantDto>>GetWinnerMatch(Guid matchId)
        {
            try
            {
                var participant = await _matchService.GetParticipantWinner(matchId);
                return participant;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
