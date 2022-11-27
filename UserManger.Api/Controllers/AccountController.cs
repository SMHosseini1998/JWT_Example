using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManger.Api.Dtos;
using UserManger.Api.Interfaces;
using UserManger.Api.Model;

namespace UserManger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null)
                return Unauthorized("Invalid Username");

            if (user.Locked)//true = locked
                return BadRequest("This account is loked by admin");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Invalid UserName Or Password");
            var roles = await _userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateTokenAsync(user),
                PhotoUrl = user.PhotoUrl,
                Roles=  await _userManager.GetRolesAsync(user)
        };
            
            return Ok(userDto);
        }
    }
}
