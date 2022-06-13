using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.DAL.Models;

namespace EasyTracker.API.MappingProfiles
{
	public class CurrencyBalanceMappingProfile : Profile
	{
		public CurrencyBalanceMappingProfile()
		{
			CreateMap<CurrencyBalance, CurrencyBalanceDTO>();
		}
	}
}
