using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VKR.Contracts.Comment;
using VKR.Infrastructure.Repository;

namespace VKR.AppServices.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Domain.Entities.Comment> _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(IRepository<Domain.Entities.Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }


        /// <inheritdoc />
        public async Task<List<CommentDto>> GetAllPost()
        {
            var result = await _commentRepository.GetAll()
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<CommentDto>>(result) : new List<CommentDto>();
        }

        public Task AddAsync(CommentDto model)
        {
            var comment = _mapper.Map<Domain.Entities.Comment>(model);
            return _commentRepository.AddAsync(comment);
        }

        public async Task<CommentDto> Update(CommentDto model)
        {
            var comment = _mapper.Map<Domain.Entities.Comment>(model);
            await _commentRepository.UpdateAsync(comment);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task DeleteAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                throw new Exception($"Не найдено объявления с id: {id}");
            }

            await _commentRepository.DeleteAsync(comment);
        }
    }
}