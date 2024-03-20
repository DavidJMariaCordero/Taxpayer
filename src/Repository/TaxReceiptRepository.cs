using Domain.Contracts.Repository;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Models;
using Repository.Base;

namespace Repository
{
    public class TaxReceiptRepository : RepositoryBase<TaxReceipt>, ITaxReceiptRepository
    {
        public TaxReceiptRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }
    }
}