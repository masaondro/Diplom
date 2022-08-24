using System;

namespace VKR.Contracts.UserProfile
{
    public class UserProfileMissionDto
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Guid MissionId { get; set; }
        
        /// <summary>
        /// Идентификатор профиля пользователя
        /// </summary>
        public Guid UserProfileId { get; set; }

    }
}