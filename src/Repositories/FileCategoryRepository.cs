using System;
using System.Collections.Generic;
using ElVegetarianoFurio.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ElVegetarianoFurio.Repositories
{
    public class FileCategoryRepository : ICategoryRepository
    {
        private readonly string _path;
        private readonly string _dishPath;
        public FileCategoryRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "data", "categories.json");
            _dishPath = Path.Combine(env.ContentRootPath, "data", "dishes.json");
        }

        public Category CreateCategory(Category category)
        {
            var categories = GetCategories()?.ToList() ?? new List<Category>();
            if (categories.Count == 0)
            {
                category.Id = 1;
            }
            else
            {
                category.Id = categories.Max(x => x.Id) + 1;
            }
            categories.Add(category);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(_path, json);
            return category;
        }

        public void DeleteCategory(int id)
        {
            var categories = GetCategories().Where(x => x.Id != id);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(_path, json);
        }

        public Category GetCategoryById(int id)
        {
            return GetCategories()?.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Category> GetCategories()
        {
            var json = File.ReadAllText(_path);
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
            };

            var categories = JsonSerializer.Deserialize<Category[]>(json, options);

            json = File.ReadAllText(_dishPath);
            var dishes = JsonSerializer.Deserialize<Dish[]>(json, options);

            foreach(var category in categories)
            {
                category.Dishes = dishes.Where(x => x.CategoryId == category.Id).ToList();
            }

            return categories;
        }

        public Category UpdateCategory(Category category)
        {
            var categories = GetCategories();
            var categoryToUpdate = categories.SingleOrDefault(x => x.Id == category.Id);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(_path, json);
            return category;
        }
    }
}
