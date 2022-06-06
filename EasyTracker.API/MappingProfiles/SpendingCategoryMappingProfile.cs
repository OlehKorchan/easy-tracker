using AutoMapper;
using EasyTracker.API.Models;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles
{
	public class SpendingCategoryMappingProfile : Profile
	{
		public SpendingCategoryMappingProfile()
		{
			CreateMap<SpendingCategory, SpendingCategoryGetDTO>();
			CreateMap<SpendingCategoryPostDTO, SpendingCategory>();
			CreateMap<SpendingCategoryGetDTO, SpendingCategoryResponseModel>();
			CreateMap<SpendingCategoryRequestModel, SpendingCategoryPostDTO>();
		}
	}
}