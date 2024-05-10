
using Application.DTOs;
using AutoMapper;
using Domain.Enitities;

namespace Application.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<Branch, BranchDto>().ReverseMap();
             CreateMap<Currency, CurrencyDto>().ReverseMap();
        }
    }
}
