using System;
using System.Collections.Generic;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель раздела
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Идентификатор раздела
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Название раздела
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание раздела
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// порядковый номер раздела
        /// </summary>
        public int Number { get; set; }
        
        /// <summary>
        /// Задачи, входящие в раздел
        /// </summary>
        public virtual ICollection<Mission> Mission { get; set; }
        
        /// <summary>
        /// Пользователи, прошедшие раздел
        /// </summary>
        public virtual ICollection<UserProfileSection> UserUserProfileSection { get; set; }
        
    }
}