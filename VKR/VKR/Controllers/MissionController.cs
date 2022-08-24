using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VKR.AppServices.Services;
using VKR.Contracts.Mission;
using VKR.Domain.Entities;

namespace VKR.Controllers
{
    /// <summary>
    /// Задача
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : ControllerBase
    {
        private readonly ILogger<MissionController> _logger;
        private readonly IMissionService _missionService;

        public MissionController(ILogger<MissionController> logger, IMissionService missionService)
        {
            _logger = logger;
            _missionService =missionService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _missionService.GetAllPost();
            return Ok(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MissionDto model)
        {
            await _missionService.AddAsync(model);
            return Created(string.Empty, null);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MissionDto model)
        {
            var result = await _missionService.Update(model);
            return Ok(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //Guid.TryParse(id, out var postId);
            await _missionService.DeleteAsync(id);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSection"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("{idSection:guid}")]
        [HttpGet]
        public async Task<IActionResult> FindBySectionId([FromRoute] Guid idSection)
        {
            var result = await _missionService.FindBySectionId(idSection);
            return Ok(result);
        }
        
        /// <summary>
        /// Получить миссию по id
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [Route("mission/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> FindById([FromRoute] Guid id)
        {
            var result = await _missionService.GetById(id);
            return Ok(result);
        }
    }
}