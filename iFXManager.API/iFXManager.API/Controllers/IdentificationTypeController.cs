using iFXManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iFXManager.API.Controllers
{
    [Route("api/identificationTypes")]    
    [ApiController]
    
    public class IdentificationTypeController : ControllerBase
    {
        private readonly IIdentificationTypes _identificationTypes;

        public IdentificationTypeController(IIdentificationTypes identificationTypes)
        {
            _identificationTypes = identificationTypes;
        }

        [HttpGet("GetAllIdentificationTypesAsync")]
       
        public async Task<IActionResult> GetAllIdentificationTypesAsync()
        {
            var response = await _identificationTypes.GetAllIdentificationTypesAsync();
            if (response.Any())
                return Ok(response);

            return BadRequest(response);
        }
    }
}
