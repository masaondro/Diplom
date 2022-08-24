using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VKR.Contracts.Section;

namespace VKR.AppServices.Services
{
    public interface ISectionService
    {
        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns></returns>
        public Task<List<SectionDto>> GetAllPost();
        
        /// <summary>
        /// Добавляет запись
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(SectionDto model);
        
        /// <summary>
        /// Обновляет запись
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<SectionDto> Update(SectionDto model);
        
        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}