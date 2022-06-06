using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services
{
	public class SpendingService : ISpendingService
	{
		private readonly ISpendingRepository _spendingRepository;
		private readonly IMapper _mapper;

		public SpendingService(ISpendingRepository spendingRepository, IMapper mapper)
		{
			_spendingRepository = spendingRepository;
			_mapper = mapper;
		}

		public async Task AddAsync(SpendingDTO spendingDto)
		{
			await _spendingRepository.AddAsync(_mapper.Map<Spending>(spendingDto));
		}

		public async Task DeleteAsync(SpendingDTO spendingDto)
		{
			await _spendingRepository.DeleteAsync(_mapper.Map<Spending>(spendingDto));
		}

		public async Task<SpendingDTO> GetAsync(Guid id)
		{
			return _mapper.Map<SpendingDTO>(await _spendingRepository.GetAsync(id));
		}
	}
}