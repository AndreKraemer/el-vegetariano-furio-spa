using ElVegetarianoFurio.Models;
using System.Collections.Generic;

namespace ElVegetarianoFurio.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
