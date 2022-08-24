using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;
using VKR.AppServices.Services;
using VKR.AppServices.Services.UserProfile;
using VKR.Contracts.Mission;
using VKR.Contracts.Section;
using VKR.Contracts.UserProfile;

namespace VKR.Controllers
{
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {

        private readonly ILogger<UserProfileController> _logger;
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(ILogger<UserProfileController> logger,
            IUserProfileService userProfileService)
        {
            _logger = logger;
            _userProfileService = userProfileService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("{idUser:guid}")]
        [HttpGet]
        public async Task<IActionResult> FindByUserId([FromRoute] Guid idUser)
        {
            var result = await _userProfileService.FindByUserId(idUser);
            return Ok(result);
        }
        
        /// <summary>
        /// Добавить задачу пользователю
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="missionId"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("addMission")]
        [HttpPost]
        public async Task<IActionResult> AddMissionToUserProfile(Guid userProfileId, Guid missionId)
        {
            await  _userProfileService.AddMissionToUserProfile(userProfileId, missionId);
            return Created(string.Empty, null);
        }
        

        /// <summary>
        /// Добавить раздел пользователю
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("addSection")]
        [HttpPost]
        public async Task<IActionResult> AddSectionToUserProfile(Guid userProfileId, Guid sectionId)
        {
            await  _userProfileService.AddSectionToUserProfile(userProfileId, sectionId);
            return Created(string.Empty, null);
        }
        
        /// <summary>
        /// Получить все миссии пользователя
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("getMission/{userProfileId:guid}")]
        [HttpGet]
        public async Task<IActionResult>GetAllUserProfileMision([FromRoute]Guid userProfileId)
        {
            var result = await _userProfileService.GetAllUserProfileMision(userProfileId);
            return Ok(result);
        }
        
        /// <summary>
        /// Получить все миссии пользователя
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("getSection/{userProfileId:guid}")]
        [HttpGet]
        public async Task<IActionResult>GetAllUserProfileSection([FromRoute]Guid userProfileId)
        {
            var result = await _userProfileService.GetAllUserProfileSection(userProfileId);
            return Ok(result);
        }

        /// <summary>
        /// Узнать решил ли пользователь эту задачу
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="missionId"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("isDoMission/{userProfileId}/{missionId}")]
        [HttpGet]
        public async Task<IActionResult> CheckUserProfileMission([FromRoute] Guid userProfileId, [FromRoute] Guid missionId)
        {
            var result = await _userProfileService.CheckUserProfileMission(userProfileId, missionId);
            return Ok(result);
        }
        
        /// <summary>
        /// Узнать решил ли пользователь эту задачу
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("isDoSection/{userProfileId}/{sectionId}")]
        [HttpGet]
        public async Task<IActionResult> CheckUserProfileSection([FromRoute]Guid userProfileId, [FromRoute]Guid sectionId)
        {
            var result = await _userProfileService.CheckUserProfileSection(userProfileId, sectionId);
            return Ok(result);
        }
        
        /// <summary>
        /// Узнать решил ли пользователь эту задачу
        /// </summary>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("bestUser")]
        [HttpGet]
        public async Task<IActionResult> GetBestUser()
        {
            var result = await _userProfileService.GetBestUser();
            return Ok(result);
        }
        
        /// <summary>
        /// Получить все секции
        /// </summary>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await  _userProfileService.GetAllPost();
            return Ok(result);
        }
    }
   
}