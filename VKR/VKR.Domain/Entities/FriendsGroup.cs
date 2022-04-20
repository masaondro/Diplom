using System;
using System.Collections.Generic;

namespace VKR.Domain.Entities
{
    public class FriendsGroup
    {
        /// <summary>
        /// Идентификатор группы
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Название группы
        /// </summary>
        public string GroupName { get; set; }
        
        /// <summary>
        /// Пользователи, входящие в группу
        /// </summary>
        public virtual ICollection<UserInGroup> UserInGroup { get; set; }

        /// <summary>
        /// Раздел, который пользователи будут решать
        /// </summary>
        public virtual Section Section { get; set; }
    }
}