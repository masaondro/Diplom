using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VKR.Contracts.Mission;
using VKR.Contracts.UserProfile;
using VKR.Infrastructure.Repository;
using VKR.Domain.Entities;

namespace VKR.AppServices.Services.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepository<Domain.Entities.UserProfile> _userProfileRepository;
        private readonly IRepository<Domain.Entities.UserProfileMission> _userProfileMissionRepository;
        private readonly IRepository<Domain.Entities.UserProfileSection> _userProfileSectionRepository;
        private readonly IRepository<Mission> _missionRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IRepository<Domain.Entities.UserProfile> userProfileRepository, 
            IMapper mapper,
            IRepository<Domain.Entities.UserProfileMission> userProfileMissionRepository,
            IRepository<Domain.Entities.UserProfileSection> userProfileSectionRepository,
            IRepository<Mission> missionRepository)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
            _userProfileMissionRepository = userProfileMissionRepository;
            _userProfileSectionRepository = userProfileSectionRepository;
            _missionRepository = missionRepository;
        }
        
        public Task AddAsync(UserProfileDto model)
        {
            var post = _mapper.Map<Domain.Entities.UserProfile>(model);
            return _userProfileRepository.AddAsync(post);
        }
        
        public async Task<List<UserProfileDto>> FindByUserId(Guid userId)
        {
            var result = await _userProfileRepository.GetAllFiltered(m =>  m.User.Id == userId.ToString())
                .Include(up => up.UserProfileMission)
                .Include(up => up.UserProfileSection)
                .Include(up => up.User)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<UserProfileDto>>(result) : new List<UserProfileDto>();
        }

        public Task AddMissionToUserProfile(Guid userProfileId, Guid missionId)
        {
            //увеличить рейтинг пользователя
            var missionDto = _missionRepository.GetByIdAsync(missionId).Result;
            var userProfile = _userProfileRepository.GetByIdAsync(userProfileId).Result;
            userProfile.Rating += missionDto.Score;
            _userProfileRepository.UpdateAsync(userProfile);
            //добавить задачу
            var userProfileMissionDto = new UserProfileMissionDto{UserProfileId = userProfileId, MissionId = missionId};
            var userProfileMission = _mapper.Map<UserProfileMission>(userProfileMissionDto);
            return _userProfileMissionRepository.AddAsync(userProfileMission);
        }
        
        public Task AddSectionToUserProfile(Guid userProfileId, Guid sectionId)
        {
            var userProfileSectionDto = new UserProfileSectionDto{UserProfileId = userProfileId, SectionId = sectionId};
            var userProfileSection = _mapper.Map<UserProfileSection>(userProfileSectionDto);
            return _userProfileSectionRepository.AddAsync(userProfileSection);
        }
        
        public async Task<List<UserProfileMissionDto>> GetAllUserProfileMision(Guid userProfileId)
        {
            
            var result = await _userProfileMissionRepository.GetAllFiltered(m =>  m.UserProfileId == userProfileId)
                .Include(up => up.Mission)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<UserProfileMissionDto>>(result) : new List<UserProfileMissionDto>();
        }
        
        public async Task<List<UserProfileSectionDto>> GetAllUserProfileSection(Guid userProfileId)
        {
            var result = await _userProfileSectionRepository.GetAllFiltered(m =>  m.UserProfileId == userProfileId)
                .Include(up => up.Section)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<UserProfileSectionDto>>(result) : new List<UserProfileSectionDto>();
        }

        public async Task<List<UserProfileMissionDto>> CheckUserProfileMission(Guid userProfileId, Guid missionId)
        {
            var result = await _userProfileMissionRepository.GetAllFiltered(u =>
                u.MissionId == missionId && u.UserProfileId == userProfileId)
                .ToListAsync();
            return result.Count > 0 ? _mapper.Map<List<UserProfileMissionDto>>(result) : new List<UserProfileMissionDto>();
        }
        
        public async Task<List<UserProfileSectionDto>> CheckUserProfileSection(Guid userProfileId, Guid sectionId)
        {
            var result = await _userProfileSectionRepository.GetAllFiltered(u =>
                    u.SectionId == sectionId && u.UserProfileId == userProfileId)
                .ToListAsync();
            return result.Count > 0 ? _mapper.Map<List<UserProfileSectionDto>>(result) : new List<UserProfileSectionDto>();
        }

        public async Task<List<UserProfileDto>> GetBestUser()
        {
            var result = await _userProfileRepository.GetAll().OrderBy(up => up.Rating).Take(20)
                .Include(u => u.User)
                .ToListAsync();
            return result.Count > 0 ? _mapper.Map<List<UserProfileDto>>(result) : new List<UserProfileDto>();
        }
        
        public async Task<List<UserProfileDto>> GetAllPost()
        {
            var result = await  _userProfileRepository.GetAll()
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<UserProfileDto>>(result) : new List<UserProfileDto>();
        }
    }
}