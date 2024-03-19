
using Domain.Contracts.DTOs.TaxReceipts;
using Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaxPayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxReceiptController : BaseCrudController<TaxReceiptView, TaxReceiptCreateRequest, TaxReceiptUpdateRequest>
    {
        public TaxReceiptController(ITaxReceiptService service) : base(service)
        {
        }
    }
}