using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles
{
	public class SpendingMappingProfile : Profile
	{
		public SpendingMappingProfile()
		{
			CreateMap<Spending, SpendingDTO>().ReverseMap();
		}
	}
}