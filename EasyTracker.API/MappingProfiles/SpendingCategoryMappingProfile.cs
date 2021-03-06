using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles;

public class SpendingCategoryMappingProfile : Profile
{
    public SpendingCategoryMappingProfile()
    {
        CreateMap<SpendingCategory, SpendingCategoryGetDTO>()
            .ForMember(sc => sc.Spendings,
                options => options.MapFrom(
                    sc => sc.Spendings));

        CreateMap<SpendingCategoryPostDTO, SpendingCategory>();

        CreateMap<SpendingCategoryGetDTO, SpendingCategoryResponseModel>()
            .ForMember(sc => sc.Spendings,
                options => options.MapFrom(
                    scd => scd.Spendings));

        CreateMap<SpendingCategoryRequestModel, SpendingCategoryPostDTO>();
    }
}
