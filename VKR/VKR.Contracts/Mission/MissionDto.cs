using System;
using System.Collections.Generic;
using VKR.Contracts.Comment;

namespace VKR.Contracts.Mission
{
    public class MissionDto : DtoBase
    {
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Текст задачи
        /// </summary>
        public string TaskText { get; set; }
        
        /// <summary>
        /// Уровень задачи
        /// </summary>
        public int Level { get; set; }
        
        /// <summary>
        /// Баллы за решение задачи
        /// </summary>
        public int Score { get; set; }
        
        /// <summary>
        /// Идентификатор раздела, к которому относится задача
        /// </summary>
        public Guid SectionId { get; set; }
        
        /// <summary>
        /// Клмментарии к задаче
        /// </summary>
        public List<CommentDto> Comment { get; set; }
        
        
    }
}