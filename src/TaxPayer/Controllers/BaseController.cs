
using Domain.Contracts.Common;
using Microsoft.AspNetCore.Mvc;

namespace TaxPayer.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult ProcessResponse<TIdType>(AppResponse baseResponse)
        {
            if (baseResponse.Succeeded) return Ok(baseResponse);

            var code = (int)baseResponse.Errors[0].Code;
            return StatusCode(code, baseResponse);
        }
    }
}