using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VKR.Contracts.Section;
using VKR.Infrastructure.Repository;

namespace VKR.AppServices.Services
{
    public class SectionService : ISectionService
    {
        private readonly IRepository<Domain.Entities.Section> _sectionRepository;
        private readonly IMapper _mapper;

        public SectionService(IRepository<Domain.Entities.Section>  sectionRepository, IMapper mapper)
        {
            _sectionRepository =  sectionRepository;
            _mapper = mapper;
        }


        /// <inheritdoc />
        public async Task<List<SectionDto>> GetAllPost()
        {
            var result = await  _sectionRepository.GetAll().OrderBy(s => s.Number)
                .Include(m => m.Mission)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<SectionDto>>(result) : new List<SectionDto>();
        }

        public Task AddAsync(SectionDto model)
        {
            var section = _mapper.Map<Domain.Entities.Section>(model);
            return  _sectionRepository.AddAsync(section);
        }

        public async Task<SectionDto> Update(SectionDto model)
        {
            var post = _mapper.Map<Domain.Entities.Section>(model);
            await  _sectionRepository.UpdateAsync(post);
            return _mapper.Map<SectionDto>(post);
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await  _sectionRepository.GetByIdAsync(id);
            if (post == null)
            {
                throw new Exception($"Не найдено объявления с id: {id}");
            }

            await  _sectionRepository.DeleteAsync(post);
        }
    }
}