using BurakNews.Core.Entities;
using BurakNews.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakNews.Auth.Services
{
    public class UserService
    {
        private readonly UserManager _userManager;

        public UserService(UserManager userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(string username, string email, string password)
        {
            var user = new AppUser
            {
                UserName = username,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            return result;
        }
        public async Task<List<AppUser>> GetAllUsers()
        {
            var userList = await _userManager.Users.ToListAsync();
            return userList;
        }
        public async Task<AppUser> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user;
        }

        public async Task<IdentityResult> UpdateUserAsync(AppUser user)
        {
            var result = await _userManager.UpdateAsync(user);

            return result;
        }

        public async Task<IdentityResult> DeleteUserAsync(AppUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result;
        }
    }
}
