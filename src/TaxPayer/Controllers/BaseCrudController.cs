
using Domain.Contracts.Common;
using Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TaxPayer.Controllers
{
    public class BaseCrudController<TList, TCreate, TUpdate> : BaseController
    {
        protected IBaseCrudService _service;

        public BaseCrudController(IBaseCrudService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListAll([FromQuery] PageRequest request)
        {
            var response = await _service.ListAll<TList>(request);

            if (!response.Succeeded) return ProcessResponse<long>(response);

            var responseMetaData = ((AppSuccessResponse<PagedResult<TList>>)response).Value.MetaData;
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(responseMetaData));

            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _service.GetById<long, TList>(id);
            return ProcessResponse<long>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreate request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _service.Create<TCreate, TList>(request);
            return !response.Succeeded ? ProcessResponse<long>(response) : Created("BaseCreate", response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TUpdate request, bool autoDeleteDetails = true)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _service.Update(request, autoDeleteDetails);
            return ProcessResponse<long>(response);
        }

        [HttpPatch]
        public async Task<IActionResult> SetStatus(long id, string status)
        {
            // if (!ModelState.IsValid) return BadRequest(ModelState);
            //
            // var response = await _service.SetStatus(id, status);
            // return !response.Succeeded ? ProcessError<long>(response) : Ok(response);
            return Ok(new AppSuccessResponse("Nothing Here.."));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _service.Delete(id);
            return ProcessResponse<long>(response);
        }
    }
}