using BurakNews.Auth.Services;
using BurakNews.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurakNews.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public AdminController(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region User
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(model.UserName, model.Email, model.Password);

                if (result.Succeeded)
                {
                    // Kullanıcı başarıyla oluşturuldu, yönlendirme yapabilirsiniz
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Kullanıcı oluşturma başarısız oldu, hataları gösterin
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var userViewModels = users.Select(u => new UserViewModel
            {
                Username = u.UserName,
                Email = u.Email
            }).ToList();

            return View(userViewModels);
        }
        #endregion
        #region Role
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var role = await _roleService.CreateRoleAsync(roleName);
            if (role.Succeeded)
            {
                return RedirectToAction(nameof(AdminController.GetAllRoleList));
            }
            return View();
        }
        public async Task<IActionResult> GetAllRoleList()
        {
            var roles = await _roleService.GetAllRole();
            return View(roles);
        }
        #endregion

    }
}
