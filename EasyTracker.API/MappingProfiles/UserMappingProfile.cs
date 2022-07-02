using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserStatisticsDTO>()
            .ForMember(ud => ud.Salaries,
                options =>
                    options.MapFrom((u, _, _, context) => u.Salaries))
            .ForMember(ud => ud.SpendingCategories,
                options =>
                    options.MapFrom((u, _, _, context) => u.SpendingCategories))
            .ForMember(ud => ud.CurrencyBalances,
                options => options.MapFrom(
                    (u, _, _, context) => u.CurrencyBalances));

        CreateMap<UserStatisticsDTO, UserStatisticsResponseModel>()
            .ForMember(
                us => us.SpendingCategories,
                options => options.MapFrom(
                    (ud, _, _, context) => ud.SpendingCategories))
            .ForMember(
                us => us.Salaries,
                options => options.MapFrom(
                    (ud, _, _, context) => ud.Salaries));
    }
}
