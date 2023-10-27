using AutoMapper;
using SampleProject.Application.Commands.Company;
using SampleProject.Domain.Models;

namespace SampleProject.Application.Mapping;

public class CompanyMapping : Profile
{
    public CompanyMapping()
    {
        CreateMap<CreateCompanyAddressDto, Address>();

        CreateMap<UpdateCompanyAddressDto, Address>();

        CreateMap<CreateCompanyCommand, Company>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<UpdateCompanyCommand, Company>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<DeleteCompanyCommand, Company>();
    }
}