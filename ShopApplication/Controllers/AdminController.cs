using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApplication.Models;
using ShopApplication.Services.Interfaces;
using ShopApplication.ViewModel;

namespace ShopApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private const int PAGES_COUNT = 10;

        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IPaginationService _paginationService;

        public AdminController(IUserService userService, UserManager<User> userManager,
            IPaginationService paginationService)
        {
            _userService = userService;
            _userManager = userManager;
            _paginationService = paginationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var users = await _userService.GetItemsAsync((page - 1) * PAGES_COUNT, PAGES_COUNT);
            var count = await _userService.ItemsTotal();
            var indexModel = _paginationService.CreateIndexViewModel(page, count, PAGES_COUNT, users);
            return View(indexModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (result.Succeeded)
            {
                return Ok(user.PasswordHash);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserName(string userId, string newUserName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.SetUserNameAsync(user, newUserName);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
