using BurakNews.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakNews.Auth.Services
{
    public class RoleService
    {
        private readonly RoleManager _roleManager;

        public RoleService(RoleManager roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var role = new AppRole { Name = roleName };

            var result = await _roleManager.CreateAsync(role);

            return result;
        }
        public async Task<List<AppRole>> GetAllRole()
        {
            var roleList = _roleManager.Roles.ToList();
            return roleList;
        }
    }
}
