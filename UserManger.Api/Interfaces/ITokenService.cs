using UserManger.Api.Model;

namespace UserManger.Api.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(User User);
    }
}