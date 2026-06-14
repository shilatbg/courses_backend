using Clean.Core.Entities;
using Clean.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repositories
{
    public class CategoriesRepositories : ICategoriesRepositories
    {
        private readonly DataContext _context;

        public CategoriesRepositories(DataContext context)
        {
            _context = context;
        }

        public List<Categories> GetAll()
        {
            return _context.Categories
                .Include(c => c.Courses)
                .ToList();
        }

        public Categories GetById(int id)
        {
            return _context.Categories
                .Include(c => c.Courses)
                .FirstOrDefault(x => x.id == id);
        }

        public Categories Add(Categories categories)
        {
            _context.Categories.Add(categories);
            _context.SaveChanges();
            return categories;
        }

        public Categories Update(int id, Categories categories)
        {
            var existingCategory = _context.Categories.FirstOrDefault(x => x.id == id);

            if (existingCategory == null)
                return null;

            existingCategory.name = categories.name;
            existingCategory.description = categories.description;

            _context.SaveChanges();
            return existingCategory;
        }

        public bool Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.id == id);

            if (category == null)
                return false;

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}
