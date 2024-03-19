using Domain.Contracts.Common;
using Domain.Contracts.DTOs.Contributors;
using Domain.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Models;
using Repository.Base;

namespace Repository
{
    public class ContributorRepository : RepositoryBase<Contributor>, IContributorRepository
    {
        public ContributorRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public async Task<PagedResult<Contributor>> GetAll(PageRequest request)
        {
            await using var context = GetContext();

            var data = context.Set<Contributor>()
                        .Include(c => c.TaxReceipts)
                        .AsNoTracking();

            return await PagedResult<Contributor>.ToPagedResult(data, request.PageNumber, request.PageSize);
        }
    }
}