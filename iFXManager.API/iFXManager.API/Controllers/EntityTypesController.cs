using iFXManager.DAL.Models;
using iFXManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iFXManager.API.Controllers
{
    [Route("api/entityTypes")]
    [ApiController]
    public class EntityTypesController : ControllerBase
    {
        private readonly IEntityTypes _entityTypes;

        public EntityTypesController(IEntityTypes entityTypes)
        {
            _entityTypes = entityTypes;
        }

        [HttpGet("GetAllEntityTypesAsync")]        
        public async Task<IActionResult> GetAllEntityTypesAsync()
        {
            var response = await _entityTypes.GetAllEntityTypesAsync();
            if (response.Any())
                return Ok(response);

            return BadRequest(response);
        }
    }
}
