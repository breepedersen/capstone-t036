using JuniorRangers_API.Models;

namespace JuniorRangers_API.Models
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
