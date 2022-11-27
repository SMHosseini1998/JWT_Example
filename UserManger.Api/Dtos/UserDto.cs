using UserManger.Api.Model;

namespace UserManger.Api.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string? PhotoUrl { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
