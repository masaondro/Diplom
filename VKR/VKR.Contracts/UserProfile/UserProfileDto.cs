using System.Collections.Generic;
using VKR.Domain.Entities;

namespace VKR.Contracts.UserProfile
{
    public class UserProfileDto: DtoBase
    {
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
        public List<Domain.Entities.Mission> Mission { get; set; }
        
        /// <summary>
        /// Разделы, пройденные пользователем
        /// </summary>
        public List<Domain.Entities.Section> Section { get; set; }
    }
}