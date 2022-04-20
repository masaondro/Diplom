using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VKR.Contracts.Comment;

namespace VKR.AppServices.Services
{
    public interface ICommentService
    {
        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns></returns>
        public Task<List<CommentDto>> GetAllPost();
        
        /// <summary>
        /// Добавляет запись
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(CommentDto model);
        
        /// <summary>
        /// Обновляет запись
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CommentDto> Update(CommentDto model);
        
        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}