using System;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель клмментария
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Идентификатор комментария
        /// </summary>
        public Guid Id { get; set; }
        
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
        public Guid UserProfileId { get; set; }
        
        /// <summary>
        /// Пользователь (автор комментария)
        /// </summary>
        public virtual UserProfile User { get; set; }
        
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid MissionId { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        public virtual Mission Mission { get; set; }

    }
}