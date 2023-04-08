using CleanArchMvc.Domain.Entites;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) 
        {
            _context= context;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
           _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
           return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategorytByIdAsync(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> RemoveCategoryAsync(Category category)
        {
           _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
           _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
