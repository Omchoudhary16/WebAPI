using EOD_Db_Layer.Model;
using EOD_Service_Layer.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EOD_WebAPI_Layer.Controllers
{

    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EODController : ControllerBase
    {
        private readonly IEodService _eodService;

        public EODController(IEodService eodService)
        {
           this._eodService = eodService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EodModel>>> Get()
        {
            var eodModels = await _eodService.GetAsync();
            return Ok(eodModels);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<EodModel>> Get(string id)
        {
            var eodModel = await _eodService.GetAsync(id);

            if (eodModel == null)
            {
                return NotFound();
            }

            return Ok(eodModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]EodModel newEodModel )
        {
            await _eodService.CreateAsync(newEodModel);

            return CreatedAtAction(nameof(Get), new { id = newEodModel.Id }, newEodModel);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, EodModel updatedEodModel)
        {
            var eodModel = await _eodService.GetAsync(id);

            if (eodModel == null)
            {
                return NotFound();
            }

            updatedEodModel.Id = eodModel.Id;

            await _eodService.UpdateAsync(id, updatedEodModel);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var eodModel = await _eodService.GetAsync(id);

            if (eodModel == null)
            {
                return NotFound();
            }

            await _eodService.RemoveAsync(id);

            return NoContent();
        }
    }
}
