using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;

namespace EasyTracker.API.MappingProfiles;

public class MainCurrencyRequestMappingProfile : Profile
{
    public MainCurrencyRequestMappingProfile()
    {
        CreateMap<MainCurrencyRequestModel, MainCurrencyRequestDTO>();
    }
}
