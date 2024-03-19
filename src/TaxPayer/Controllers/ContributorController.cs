
using Domain.Contracts.Common;
using Domain.Contracts.DTOs.Contributors;
using Domain.Contracts.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistence.Models;

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