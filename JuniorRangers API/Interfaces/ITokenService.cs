using JuniorRangers_API.Models;

namespace JuniorRangers_API.Models
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
