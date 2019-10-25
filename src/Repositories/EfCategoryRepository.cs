using System.Collections.Generic;
using System.Linq;
using ElVegetarianoFurio.Models;
using Microsoft.EntityFrameworkCore;

namespace ElVegetarianoFurio.Repositories
{
    public class EfCategoryRepository : ICategoryRepository
    {

        private readonly VegiContext _vegiContext;

        public EfCategoryRepository(VegiContext vegiContext)
        {
            _vegiContext = vegiContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = _vegiContext.Categories
                                    .AsNoTracking()
                                    .Include(x => x.Dishes).AsNoTracking()
                                    .ToList();

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            var category = _vegiContext.Categories.Find(id);
            _vegiContext.Entry(category).Collection(x => x.Dishes).Load();
            return category;
        }

        public Category CreateCategory(Category category)
        {
            _vegiContext.Categories.Add(category);
            _vegiContext.SaveChanges();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.Id);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
            _vegiContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            _vegiContext.Categories.Remove(category);
            _vegiContext.SaveChanges();
        }
    }
}