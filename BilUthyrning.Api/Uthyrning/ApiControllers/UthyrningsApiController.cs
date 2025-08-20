// baskod f;r apicontroller
using BilUthyrning.Api.Services.Interfaces;
using BilUthyrning.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace BilUthyrning.Api.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UthyrningsApiController : ControllerBase
    {
        private readonly IUthyrningService _uthyrningService;
        public UthyrningsApiController(IUthyrningService uthyrningService)
        {
            _uthyrningService = uthyrningService;
        }

        // POST: api/uthyrningar
        [HttpPost]
        public async Task<ActionResult<UthyrningsModel>> RegistreraUtlamningAvBil([FromBody] UthyrningsModel uthyrning)
        {
            if (uthyrning == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _uthyrningService.RegistreraUtlamningAvBilAsync(uthyrning);
        }

        // POST: api/uthyrningar/aterlamning
        [HttpPost("aterlamning")]
        public async Task<ActionResult<UthyrningsModel>> RegistreraAterlamningAvBil([FromBody] AterlamningModel aterlamning)
        {
            if (aterlamning == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _uthyrningService.RegistreraAterlamningAvBilAsync(aterlamning);
            
            if (result == null)
            {
                return NotFound("Ingen matchande uthyrning hittades för det angivna bokningsnumret.");
            }

            return Ok(result);
        }
    }
}