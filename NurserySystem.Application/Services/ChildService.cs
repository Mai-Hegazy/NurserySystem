using NurserySystem.Application.DTOs;
using NurserySystem.Application.DTOsMapping;
using NurserySystem.Domain.Interfaces;

namespace NurserySystem.Application.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;
        
        public ChildService(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<List<ChildDto>> GetAllChildrenAsync()
        {
            var children = await _childRepository.GetAllAsync();
            return children.Select(c => c.ToDto()).ToList();
        }

        public async Task<ChildDto?> GetChildByIdAsync(int id)
        {
            var child = await _childRepository.GetByIdAsync(id);

            if (child == null)
                return null;

            return child.ToDto();
        }

        public async Task<ChildDto> AddChildAsync(ChildDto childDto)   
        {
            var child = childDto.ToEntity();
            await _childRepository.AddAsync(child);

            return child.ToDto();
        }

        public async Task<bool> UpdateChildAsync(ChildDto childDto)
        {
            var child = await _childRepository.GetByIdAsync(childDto.ID ?? 0);
            if (child == null)
                return false;
            
            childDto.ToEntity(ref child);

            await _childRepository.UpdateAsync(child);
            return true;
        }

        public async Task<bool> DeleteChildAsync(int id)
        {
            var child = await _childRepository.GetByIdAsync(id);
            if (child == null) 
                return false;

            await _childRepository.DeleteAsync(child.ID);
            return true;
        }
    }
}