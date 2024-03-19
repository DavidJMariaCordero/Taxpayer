using AutoMapper;
using Domain.Contracts.Repository;
using Domain.Contracts.Services;
using Persistence.Models;
using Services.Base;

namespace Services
{
    public class TaxReceiptService : BaseCrudService<TaxReceipt>, ITaxReceiptService
    {
        public TaxReceiptService(ITaxReceiptRepository taxReceiptRepository, IMapper mapper) : base(taxReceiptRepository, mapper)
        {
        }


    }
}