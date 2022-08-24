using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VKR.Contracts.Mission;
using VKR.Domain.Entities;
using VKR.Infrastructure.Repository;
using Guid = System.Guid;

namespace VKR.AppServices.Services
{
    public class MissionService : IMissionService
    {
        
        private readonly IRepository<Domain.Entities.Mission> _missionRepository;
        private readonly IMapper _mapper;

        public MissionService(IRepository<Domain.Entities.Mission> missionRepository, IMapper mapper)
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }


        /// <inheritdoc />
        public async Task<List<MissionDto>> GetAllPost()
        {
            var result = await _missionRepository.GetAll()
                .Include(m => m.Comment)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<MissionDto>>(result) : new List<MissionDto>();
        }
        
        public async Task<Mission> GetById(Guid id)
        {
            return await _missionRepository.GetByIdAsync(id);
        }

        public Task AddAsync(MissionDto model)
        {
            var post = _mapper.Map<Domain.Entities.Mission>(model);
            return _missionRepository.AddAsync(post);
        }

        public async Task<MissionDto> Update(MissionDto model)
        {
            var post = _mapper.Map<Domain.Entities.Mission>(model);
            await _missionRepository.UpdateAsync(post);
            return _mapper.Map<MissionDto>(post);
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await _missionRepository.GetByIdAsync(id);
            if (post == null)
            {
                throw new Exception($"Не найдено объявления с id: {id}");
            }

            await _missionRepository.DeleteAsync(post);
        }

        public async Task<List<MissionDto>> FindBySectionId(Guid sectionId)
        {
            var result = await _missionRepository.GetAllFiltered(m =>  m.SectionId == sectionId)
                .Include(m => m.Comment)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<MissionDto>>(result) : new List<MissionDto>();
        }
    }
}