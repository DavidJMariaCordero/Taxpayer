using AutoMapper;
using Domain.Contracts.DTOs.Contributors;
using Domain.Contracts.DTOs.TaxReceipts;
using Persistence.Models;

namespace TaxPayer.MapperProfiles
{
    public class TaxPayerMapperProfile : Profile
    {
        public TaxPayerMapperProfile()
        {
            CreateMap<Contributor, ContributorCreateRequest>().ReverseMap();
            CreateMap<Contributor, ContributorUpdateRequest>().ReverseMap();
            CreateMap<Contributor, ContributorView>().ReverseMap();

            CreateMap<TaxReceipt, TaxReceiptCreateRequest>().ReverseMap();
            CreateMap<TaxReceipt, TaxReceiptUpdateRequest>().ReverseMap();
            CreateMap<TaxReceipt, TaxReceiptView>().ReverseMap();
        }
    }
}
