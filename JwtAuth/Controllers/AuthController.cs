using System.Threading.Tasks;
using JwtAuth.Dtos;
using JwtAuth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JwtAuth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ISignInManager _signInManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserManager userManager, ISignInManager signInManager, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginDto model)
        {
            var msg = string.Empty;
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                msg = $"{model.UserName} 此用户不存在。";
                _logger.LogWarning(msg);
                return BadRequest(msg);
            }

            var token = await _signInManager.SignInPasswordAsync(user, model.Password);
            if (token==null)
            {
                msg = $"登录失败，请您重新登录";
                return BadRequest(msg);
            }
            Response.Headers.Add("Authorization", token);
            
            return Ok($"{model.UserName} ni zheng zai deng lu");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDto model)
        {
            var msg = "您访问的是注册页面。";

            var exsit = await _userManager.IsExists(model.UserName);
            if (exsit)
            {
                msg = $"尊敬的 {model.UserName} ， 您已注册成功， 请您登录。";
                return BadRequest(msg);
            }

            var result = await _userManager.CreatUserAsync(model);
            if (!result)
            {
                msg = $"注册失败，请您重新注册";
                return BadRequest(msg);
            }

            msg = $"{model.UserName}注册成功";
            return Ok(msg);
        }
    }
}