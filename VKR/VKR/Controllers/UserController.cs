using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VKR.AppServices.Services;
using VKR.Contracts.User;


namespace VKR.Controllers
{
    /// <summary>
    /// Пользователи
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        /// <summary>
        /// Контроллер для работы с пользователем
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Вход по логину \ паролю
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var loginResponce = await _userService.Login(dto);
            return Ok(loginResponce);
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            await _userService.Register(dto);
            return Ok();
        }

        /// <summary>
        /// Подьверждение email
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailDto dto)
        {
            await _userService.ConfirmEmail(dto);
            return Ok();
        }

        /// <summary>
        /// Добавить нового модератора
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("createModerator")]
        public async Task<IActionResult>  CreateModerator(CreateModeratorDto dto)
        {
            dto.CurrentUserId = User.FindFirst("UserId")?.Value;
            await _userService.CreateModerator(dto);
            return Ok();
        }
    }
}