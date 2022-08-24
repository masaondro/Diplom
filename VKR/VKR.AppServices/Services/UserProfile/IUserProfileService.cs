using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VKR.Contracts.UserProfile;
using VKR.Domain.Entities;

namespace VKR.AppServices.Services.UserProfile
{
    public interface IUserProfileService
    {
        /// <summary>
        /// Добавляет профиль пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddAsync(UserProfileDto model);

        /// <summary>
        /// Получить данные о пользователе по Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<UserProfileDto>> FindByUserId(Guid userId);

        /// <summary>
        /// Добавить задачу пользователю
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="missionId"></param>
        /// <returns></returns>
        Task AddMissionToUserProfile(Guid userProfileId, Guid missionId);

        /// <summary>
        /// Добавить раздел пользователю
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public Task AddSectionToUserProfile(Guid userProfileId, Guid sectionId);

        /// <summary>
        /// Получить все миссии пользователя
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        Task<List<UserProfileMissionDto>> GetAllUserProfileMision(Guid userProfileId);

        /// <summary>
        /// Получить все разделы пользователя
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        Task<List<UserProfileSectionDto>> GetAllUserProfileSection(Guid userProfileId);

        /// <summary>
        /// Проверяет решил ли пользователь эту задачу
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="missionId"></param>
        /// <returns></returns>
        Task<List<UserProfileMissionDto>> CheckUserProfileMission(Guid userProfileId, Guid missionId);

        /// <summary>
        /// Проверяет прошел ли пользователь раздел
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        Task<List<UserProfileSectionDto>> CheckUserProfileSection(Guid userProfileId, Guid sectionId);

        /// <summary>
        /// Получить 20 пользователей с лучшим рейтингом
        /// </summary>
        /// <returns></returns>
        Task<List<UserProfileDto>> GetBestUser();

        Task<List<UserProfileDto>> GetAllPost();
    }
}