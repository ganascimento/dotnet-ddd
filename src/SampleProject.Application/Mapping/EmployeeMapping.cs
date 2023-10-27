using AutoMapper;
using SampleProject.Application.Commands.Employee;
using SampleProject.Domain.Models;

namespace SampleProject.Application.Mapping;

public class EmployeeMapping : Profile
{
    public EmployeeMapping()
    {
        CreateMap<CreateEmployeeAddressDto, Address>();

        CreateMap<UpdateEmployeeAddressDto, Address>();

        CreateMap<CreateEmployeePhoneDto, Phone>();

        CreateMap<UpdateEmployeePhoneDto, Phone>();

        CreateMap<CreateEmployeeCommand, Employee>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
            .ForMember(dest => dest.Cellphone, opt => opt.MapFrom(src => src.Cellphone));

        CreateMap<UpdateEmployeeCommand, Employee>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
            .ForMember(dest => dest.Cellphone, opt => opt.MapFrom(src => src.Cellphone));

        CreateMap<DeleteEmployeeCommand, Employee>();
    }
}