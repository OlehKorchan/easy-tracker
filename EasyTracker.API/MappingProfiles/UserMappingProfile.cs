using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.API.Models;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserStatisticsDTO>()
                .ForMember(ud => ud.Salaries, options => options.Ignore())
                .ForMember(ud => ud.SpendingCategories, options => options.Ignore());

            CreateMap<UserStatisticsDTO, UserStatisticsResponseModel>()
                .ForMember(us => us.SpendingCategories, options => options.Ignore())
                .ForMember(us => us.Salaries, options => options.Ignore());
        }
    }
}
