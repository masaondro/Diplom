using System;
using System.Collections.Generic;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель задачи
    /// </summary>
    public class Mission
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Текст задачи
        /// </summary>
        public string TaskText { get; set; }
        
        /// <summary>
        /// Идентификатор раздела, к которому относится задача
        /// </summary>
        public Guid SectionId { get; set; }
        
        /// <summary>
        /// Уровень задачи
        /// </summary>
        public int Level { get; set; }
        
        /// <summary>
        /// Баллы за решение задачи
        /// </summary>
        public int Score { get; set; }
        
        /// <summary>
        /// Пользователи, решившие задачу
        /// </summary>
        public virtual ICollection<User> User { get; set; }
        
        /// <summary>
        /// Раздел, к которому относится задача
        /// </summary>
        public virtual Section Section { get; set; }
        
        /// <summary>
        /// Клмментарии к задаче
        /// </summary>
        public virtual ICollection<Comment> Comment { get; set; }
    }
}