using iFXManager.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iFXManager.API.Controllers
{
    [Route("api/positions")]
    [ApiController]
    
    public class PositionsController : ControllerBase
    {
        private readonly IPositions _positions;

        public PositionsController(IPositions positions)
        {
            _positions = positions;
        }

        [HttpGet("GetAllPositionsAsync")]   
        public async Task<IActionResult> GetAllPositionsAsync()
        {
            var response = await _positions.GetAllPositionsAsync();
            if (response.Any())
                return Ok(response);

            return BadRequest(response);
        }
    }
}
