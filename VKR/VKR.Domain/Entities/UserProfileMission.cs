using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель связывающая польщователя и решенные им задачи
    /// </summary>
    public class UserProfileMission
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid MissionId { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        public virtual Mission Mission{ get; set; }

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