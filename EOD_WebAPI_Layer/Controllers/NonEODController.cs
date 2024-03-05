using EOD_Db_Layer.Model;
using EOD_Service_Layer.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EOD_WebAPI_Layer.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class NonEODController : ControllerBase
    {
        private readonly INonEODService _nonEodService;

        public NonEODController(INonEODService nonEodService)
        {
            this._nonEodService = nonEodService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NonEODModel>>> Get()
        {
            var nonEODModels = await _nonEodService.GetAsync();
            return Ok(nonEODModels);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<NonEODModel>> Get(string id)
        {
            var nonEODModel = await _nonEodService.GetAsync(id);

            if (nonEODModel == null)
            {
                return NotFound();
            }

            return Ok(nonEODModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NonEODModel newNonEODModel)
        {
            await _nonEodService.CreateAsync(newNonEODModel);

            return CreatedAtAction(nameof(Get), new { id = newNonEODModel.Id }, newNonEODModel);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, NonEODModel updatedNonEODModel)
        {
            var NonEODModel = await _nonEodService.GetAsync(id);

            if (NonEODModel == null)
            {
                return NotFound();
            }

            updatedNonEODModel.Id = NonEODModel.Id;

            await _nonEodService.UpdateAsync(id, updatedNonEODModel);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var NonEODModel = await _nonEodService.GetAsync(id);

            if (NonEODModel == null)
            {
                return NotFound();
            }

            await _nonEodService.RemoveAsync(id);

            return NoContent();
        }
    }
}
