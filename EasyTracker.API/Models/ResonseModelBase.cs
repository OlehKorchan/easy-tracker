namespace EasyTracker.API.Models
{
    public class ResponseModelBase
    {
        public List<string> Errors { get; set; } = new();
    }
}
