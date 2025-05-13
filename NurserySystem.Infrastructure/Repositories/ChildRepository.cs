using Microsoft.EntityFrameworkCore;
using NurserySystem.Domain.Entities;
using NurserySystem.Domain.Interfaces;
using NurserySystem.Infrastructure.Data;

namespace NurserySystem.Infrastructure.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly NurseryDbContext _context;

        public ChildRepository(NurseryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Child>> GetAllAsync() => await _context.Children.ToListAsync();
       
        public async Task<Child> GetByIdAsync(int id) => await _context.Children.FindAsync(id);
        
        public async Task AddAsync(Child child) 
        { 
            _context.Children.Add(child); 
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(Child child) 
        {
            _context.Children.Update(child); 
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child != null) _context.Children.Remove(child);
            await _context.SaveChangesAsync();
        }
    }
}