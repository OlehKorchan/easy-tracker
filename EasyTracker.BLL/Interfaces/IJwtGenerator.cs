using EasyTracker.DAL.Models;

namespace EasyTracker.BLL.Interfaces;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}
