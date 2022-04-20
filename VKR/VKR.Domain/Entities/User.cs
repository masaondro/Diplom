using System;
using System.Collections.Generic;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string FIO { get; set; }
        
        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Общий рейтинг
        /// </summary>
        public int Rating { get; set; }
        
        /// <summary>
        /// Решенные задачи
        /// </summary>
        public virtual ICollection<Mission> Mission { get; set; }
        
        /// <summary>
        /// Разделы, пройденные пользователем
        /// </summary>
        public virtual ICollection<Section> Section { get; set; }
    }
}