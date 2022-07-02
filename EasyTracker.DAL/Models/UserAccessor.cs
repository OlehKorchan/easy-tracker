using EasyTracker.DAL.Interfaces;

namespace EasyTracker.DAL.Models;

public class UserAccessor : IUser
{
    public string Id { get; set; }
    public string UserName { get; set; }
}
