using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace webcarsAPI.Infra.Services
{
    public interface IRoleService
    {
        Task EnsureRolesAsync();
        Task EnsureRoleAsync(string roleName);
    }

    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleService> _logger;

        public RoleService(RoleManager<IdentityRole> roleManager, ILogger<RoleService> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task EnsureRolesAsync()
        {
            string[] roles = { "SuperAdmin", "Admin", "User" };

            foreach (var role in roles)
            {
                await EnsureRoleAsync(role);
            }
        }

        public async Task EnsureRoleAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Role '{roleName}' created successfully.");
                }
                else
                {
                    _logger.LogError($"Failed to create role '{roleName}': {string.Join(", ", result.Errors)}");
                }
            }
        }
    }
}