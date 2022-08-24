using System;

namespace VKR.Domain.Entities
{
    /// <summary>
    /// Модель пользователя в группе
    /// </summary>
    public class UserInGroup
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual UserProfile User { get; set; }
        
        /// <summary>
        /// Частный рейтинг
        /// </summary>
        public int ScroreInGroup { get; set; }
        
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Guid FriendsGroupIg { get; set; }
        
        /// <summary>
        /// Граппа
        /// </summary>
        public virtual FriendsGroup FriendsGroup { get; set; }
    }
}