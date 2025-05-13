using NurserySystem.Application.DTOs;

namespace NurserySystem.Application.Services
{
    public interface IChildService
    {
        Task<List<ChildDto>> GetAllChildrenAsync();
        Task<ChildDto?> GetChildByIdAsync(int id);
        Task<ChildDto> AddChildAsync(ChildDto childDto); 
        Task<bool> UpdateChildAsync(ChildDto childDto);
        Task<bool> DeleteChildAsync(int id);
    }
}