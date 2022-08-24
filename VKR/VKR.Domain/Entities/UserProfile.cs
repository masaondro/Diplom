using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Данные аккаунта
        /// </summary>
        public virtual ApplicationUser User { get; set; }
        
        /// <summary>
        /// Общий рейтинг
        /// </summary>
        public int Rating { get; set; }
        
        /// <summary>
        /// Решенные задачи
        /// </summary>
        public virtual ICollection<UserProfileMission> UserProfileMission { get; set; }
        
        /// <summary>
        /// Разделы, пройденные пользователем
        /// </summary>
        public virtual ICollection<UserProfileSection> UserProfileSection { get; set; }
    }
}