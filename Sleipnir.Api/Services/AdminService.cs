using Microsoft.AspNetCore.Identity;
using Sleipnir.Api.Data;
using Sleipnir.Api.Interfaces;
using Sleipnir.Api.Models;
using Sleipnir.Dtos.Auth;

namespace Sleipnir.Api.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public AdminService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<Status> MakeAdminAsync(UpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByEmailAsync(updatePermissionDto.Email);

            if (user is null)
                return new Status()
                {
                    StatusCode = 404,
                    Message = "Invalid User name!!!!!!!!"
                };

            await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            return new Status()
            {
                StatusCode = 200,
                Message = "User is now an ADMIN"
            };
        }

        public async Task<Status> MakeArtistAsync(UpdatePermissionDto updatePermissionDto)
        {
            var user = await _userManager.FindByEmailAsync(updatePermissionDto.Email);

            if (user is null)
                return new Status()
                {
                    StatusCode = 404,
                    Message = "Invalid User name!!!!!!!!"
                };

            await _userManager.AddToRoleAsync(user, UserRoles.Artist);

            return new Status()
            {
                StatusCode = 200,
                Message = "User is now an Moderator"
            };
        }

        public async Task<Status> SeedRolesAsync()
        {
            bool isUserRoleExists = await _roleManager.RoleExistsAsync(UserRoles.User);
            bool isOwnerRoleExists = await _roleManager.RoleExistsAsync(UserRoles.Artist);
            bool isAdminRoleExists = await _roleManager.RoleExistsAsync(UserRoles.Admin);

            if (isUserRoleExists && isOwnerRoleExists && isAdminRoleExists)
                return new Status()
                {
                    StatusCode = 200,
                    Message = "Roles Seeding is Already Done"
                };

            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Artist));
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            return new Status()
            {
                StatusCode = 200,
                Message = "Role Seeding Done Successfully"
            };
        }
    }
}
