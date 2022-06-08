using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles
{
	public class SpendingMappingProfile : Profile
	{
		public SpendingMappingProfile()
		{
			CreateMap<Spending, SpendingDTO>()
				.ForMember(sp => sp.SpendingCategory,
					options => options.Ignore());

			CreateMap<SpendingDTO, Spending>()
				.ForMember(sp => sp.SpendingCategory,
					options => options.Ignore());
		}
	}
}
