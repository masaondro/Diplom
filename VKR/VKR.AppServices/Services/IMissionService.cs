﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VKR.Contracts.Mission;
using VKR.Domain.Entities;

namespace VKR.AppServices.Services
{
    /// <summary>
    /// Сервис для работы с объявлениями
    /// </summary>
    public interface IMissionService
    {
        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        /// <returns></returns>
        public Task<List<MissionDto>> GetAllPost();
        
        /// <summary>
        /// Добавляет запись
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(MissionDto model);
        
        /// <summary>
        /// Обновляет запись
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<MissionDto> Update(MissionDto model);
        
        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}