using AutoMapper;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles
{
	public class CategoryMappingProfile : Profile
	{
		public CategoryMappingProfile() => CreateMap<MainSpendingCategory, SpendingCategory>();
	}
}
