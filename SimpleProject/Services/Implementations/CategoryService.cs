using Microsoft.EntityFrameworkCore;
using SimpleProject.Data;
using SimpleProject.Models;
using SimpleProject.Services.Interfaces;

namespace SimpleProject.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion
        #region Constructors
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }
    }
}
