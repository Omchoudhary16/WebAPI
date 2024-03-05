using EOD_Db_Layer.Model;
using EOD_Service_Layer.Implementation;
using EOD_Service_Layer.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EOD_WebAPI_Layer.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypeController : ControllerBase
    {

        private readonly IWorkTypeService _workTypeService;

        public WorkTypeController(IWorkTypeService workTypeService)
        {
            this._workTypeService = workTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkType>>> Get()
        {
            var workTypeModel = await _workTypeService.GetAsync();
            return Ok(workTypeModel);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<EodModel>> Get(string id)
        {
            var eodModel = await _workTypeService.GetAsync(id);

            if (eodModel == null)
            {
                return NotFound();
            }

            return Ok(eodModel);
        }

        [HttpPost]
        public async Task<ActionResult<EodModel>> Post(WorkType newWorkType)
        {
            await _workTypeService.CreateAsync(newWorkType);

            return CreatedAtAction(nameof(Get), new { id = newWorkType.Id }, newWorkType);
        }

    }
}
