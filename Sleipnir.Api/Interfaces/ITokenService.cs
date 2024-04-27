using Sleipnir.Dtos.Auth;
using System.Security.Claims;

namespace Sleipnir.Api.Interfaces
{
    public interface ITokenService
    {
        TokenResponse GetToken(List<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
