using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles;

public class SpendingMappingProfile : Profile
{
    public SpendingMappingProfile()
    {
        CreateMap<Spending, SpendingDTO>().ReverseMap();
        CreateMap<SpendingDTO, SpendingResponseModel>()
            .ForMember(srm => srm.CategoryName,
                options => options
                    .MapFrom(sDto => sDto.SpendingCategory.CategoryName));
        CreateMap<SpendingRequestModel, SpendingDTO>();
    }
}
