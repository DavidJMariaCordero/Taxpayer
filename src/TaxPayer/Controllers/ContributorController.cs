using Domain.Contracts.DTOs.Contributors;
using Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaxPayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributorController : BaseCrudController<ContributorView, ContributorCreateRequest, ContributorUpdateRequest>
    {
        public ContributorController(IContributorService service) : base(service)
        {
        }
    }
}