using System;

namespace VKR.Contracts.UserProfile
{
    public class UserProfileSectionDto
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid SectionId { get; set; }
        
        /// <summary>
        /// Идентификатор профиля пользователя
        /// </summary>
        public Guid UserProfileId { get; set; }

    }
}