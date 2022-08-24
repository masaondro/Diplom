using System;
using System.ComponentModel.DataAnnotations;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель связывающая польщователя и пройденные разделы
    /// </summary>
    public class UserProfileSection
    {
        /// <summary>
        /// Идентификатор раздела
        /// </summary>
        public Guid SectionId { get; set; }

        /// <summary>
        /// Секция
        /// </summary>
        public virtual Section Section { get; set; }

        /// <summary>
        /// Идентификатор профиля пользователя
        /// </summary>
        public Guid UserProfileId { get; set; }

        /// <summary>
        /// Профиль польщователя
        /// </summary>
        public virtual UserProfile UserProfile { get; set; }
    }
}