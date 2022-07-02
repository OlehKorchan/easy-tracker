using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles;

public class SalaryMappingProfile : Profile
{
    public SalaryMappingProfile()
    {
        CreateMap<Salary, SalaryDTO>().ReverseMap();
        CreateMap<SalaryDTO, SalaryResponseModel>();
        CreateMap<SalaryCreateRequestModel, SalaryDTO>();
    }
}
