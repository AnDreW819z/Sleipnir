using Microsoft.AspNetCore.Identity;

namespace Sleipnir.Api.Models
{
    public class User : IdentityUser
    {
        public string? UserAvatar { get; set; }
    }
}
