using System.Threading.Tasks;
using Identity.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password, bool isPersistent)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent, false);

            if (result.Succeeded)
            {
                return Ok("Вы вошли!");
            }
            
            return BadRequest("Вы не вошли");
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(string username, string password, string fio)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = username,
                Fio = fio
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return Ok("Успешно");
            }
                
            return BadRequest("Не получилось зарегистрироваться");
        }
        
    }
}