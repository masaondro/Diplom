using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VKR.AppServices.Services;
using VKR.Contracts.Section;
using VKR.Domain.Entities;

namespace VKR.Controllers
{
    /// <summary>
    /// Задача
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ILogger<SectionController> _logger;
        private readonly ISectionService _sectionService;

        public SectionController(ILogger<SectionController> logger, ISectionService sectionService)
        {
            _logger = logger;
            _sectionService = sectionService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await  _sectionService.GetAllPost();
            return Ok(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SectionDto model)
        {
            await  _sectionService.AddAsync(model);
            return Created(string.Empty, null);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SectionDto model)
        {
            var result = await  _sectionService.Update(model);
            return Ok(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //Guid.TryParse(id, out var postId);
            await  _sectionService.DeleteAsync(id);
            return Ok();
        }
    }
}