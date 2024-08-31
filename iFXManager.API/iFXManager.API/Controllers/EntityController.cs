using AutoMapper;
using iFXManager.API.Models;
using iFXManager.DAL.DTOs;
using iFXManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iFXManager.API.Controllers
{
    [Route("api/entity")]
    [ApiController]

    public class EntityController : ControllerBase
    {
        private readonly IEntities _entities;
        private readonly IMapper _mapper;

        public EntityController(IEntities entities, IMapper mapper)
        {
            _entities = entities;
            _mapper = mapper;
        }

        [HttpPost("save")]
        [Authorize]
        public  ActionResult Post([FromBody] EntityDto entityDto)
        {
            try
            {
                if (entityDto == null)
                {
                    return BadRequest(ModelState);
                }
                var entity = _mapper.Map<Entity>(entityDto);                

                var response = _entities.ExistEntity(entity);
                if (response.Result)
                {
                    ModelState.AddModelError("", "There is already an entity with the registered ID number.");
                    return StatusCode(404, ModelState);
                }
                _entities.SaveEntityAsync(entity);

                return Ok(entity);

            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }


        [HttpGet("GetAllEntitiesAsync")]
        public async Task<IActionResult> GetAllEntitiesAsync()
        {
            var response = await _entities.GetAllEntitiesAsync();
            if (response.Any())
                return Ok(response);

            return BadRequest(response);
        }
    }
}
