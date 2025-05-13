using Microsoft.AspNetCore.Mvc;
using NurserySystem.Application.Services;
using NurserySystem.Application.DTOs;

namespace NurserySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;
        public ChildController(IChildService childService)
        {
            _childService = childService;
        }

        // GET: api/child
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildDto>>> GetChildren()
        {
            var children = await _childService.GetAllChildrenAsync();
            return Ok(children);
        }

        // GET: api/child/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChildDto>> GetChild(int id)
        {
            var child = await _childService.GetChildByIdAsync(id);
            if (child == null)
            {
                return NotFound();
            }

            return Ok(child);
        }

        // POST: api/child
        [HttpPost]
        public async Task<ActionResult<ChildDto>> CreateChild(ChildDto childDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var child = await _childService.AddChildAsync(childDto);
            return CreatedAtAction(nameof(GetChild), new { id = child.ID }, child);
        }

        // PUT: api/child/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ChildDto>> UpdateChild(int id, ChildDto childDto)
        {
            if(id != childDto.ID)
            {   
                return BadRequest(); 
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _childService.UpdateChildAsync(childDto);
            return !updated ? NotFound() : NoContent(); 
        }
    
        // DELETE: api/child/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChildDto>> DeleteChild(int id) {
            var deleted = await _childService.DeleteChildAsync(id);
            return !deleted ? NotFound() : NoContent();
        }
    }
}