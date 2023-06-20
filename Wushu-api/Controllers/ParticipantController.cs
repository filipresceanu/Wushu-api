using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wushu_api.Services;

namespace Wushu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpDelete("delete-participant")]
        public async Task<ActionResult> Delete(Guid id) 
        {
            try
            {
                await _participantService.DeleteParticipant(id);
                return Ok("success");
            }
            catch 
            {
                return BadRequest("unable to delete participant");
            }
        }
    }
}
