using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await signInManager.PasswordSignInAsync(userLoginDto.Username,userLoginDto.Password,false,false);
            if(result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(userLoginDto.Username);
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.Username = userLoginDto.Username;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return Ok("Kullanıcı adı veya Şifre Hatalı");
            }
        }
    }
}
