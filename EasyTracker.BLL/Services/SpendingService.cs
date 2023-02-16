using AutoMapper;
using EasyTracker.BLL.DTO;
using EasyTracker.BLL.Interfaces;
using EasyTracker.DAL.Interfaces;
using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Services;

public class SpendingService : ISpendingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUser _user;

    public SpendingService(IUnitOfWork unitOfWork, IMapper mapper, IUser user)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _user = user;
    }

    public async Task AddAsync(SpendingDTO spendingDto)
    {
        await _unitOfWork.SpendingRepository.AddAsync(_mapper.Map<Spending>(spendingDto));

        _unitOfWork.SaveAsync().GetAwaiter().GetResult();
    }

    public Task DeleteAsync(SpendingDTO spendingDto)
    {
        _unitOfWork.SpendingRepository.Delete(_mapper.Map<Spending>(spendingDto));

        return _unitOfWork.SaveAsync();
    }

    public async Task<List<SpendingDTO>> GetAsync()
    {
        var userId = await _unitOfWork.UserRepository.GetUserIdByNameAsync(_user.UserName);
        var spendings = await _unitOfWork.SpendingRepository.GetAsync(userId);

        return _mapper.Map<List<SpendingDTO>>(spendings);
    }

    public async Task<SpendingDTO> GetAsync(Guid id)
    {
        return _mapper.Map<SpendingDTO>(await _unitOfWork.SpendingRepository.GetAsync(id));
    }
}
