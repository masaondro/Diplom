using System;

namespace VKR.Contracts.Comment
{
    /// <summary>
    /// DTO модель представления комментариев к задаче
    /// </summary>
    public class CommentDto : DtoBase
    {
        /// <summary>
        /// Текст комментария
        /// </summary>
        public string CommentBode { get; set; }
        
        /// <summary>
        /// Дата и время клмментария
        /// </summary>
        public DateTime CommentDate { get; set; }
        
        
        /// <summary>
        /// Идентификатор пользователя (автора комментария) 
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// Имя пользователя 
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid MissionId { get; set; }
    }
}