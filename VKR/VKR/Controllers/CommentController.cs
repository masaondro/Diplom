using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VKR.AppServices.Services;
using VKR.Contracts.Comment;



namespace VKR.Controllers
{
    /// <summary>
    /// Задача
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;

        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _commentService.GetAllPost();
            return Ok(result);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CommentDto model)
        {
            await _commentService.AddAsync(model);
            return Created(string.Empty, null);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CommentDto model)
        {
            var result = await _commentService.Update(model);
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
            await _commentService.DeleteAsync(id);
            return Ok();
        }
       
    }
}