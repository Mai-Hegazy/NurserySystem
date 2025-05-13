using NurserySystem.Domain.Entities;

namespace NurserySystem.Domain.Interfaces
{
    public interface IChildRepository
    {
        Task<List<Child>> GetAllAsync();
        Task<Child> GetByIdAsync(int id);
        Task AddAsync(Child child);
        Task UpdateAsync(Child child);
        Task DeleteAsync(int id);
    }
}