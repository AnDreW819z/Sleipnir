using Sleipnir.Dtos.Auth;

namespace Sleipnir.Api.Interfaces
{
    public interface IAdminService
    {
        Task<Status> SeedRolesAsync();
        Task<Status> MakeArtistAsync(UpdatePermissionDto updatePermissionDto);
        Task<Status> MakeAdminAsync(UpdatePermissionDto updatePermissionDto);
    }
}
