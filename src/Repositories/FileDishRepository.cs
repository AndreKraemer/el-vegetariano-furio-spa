using System;
using System.Collections.Generic;
using ElVegetarianoFurio.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ElVegetarianoFurio.Repositories
{
    public class FileDishRepository : IDishRepository
    {
        private readonly string _path;
        public FileDishRepository(IWebHostEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "data", "dishes.json");
        }

        public Dish CreateDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(int id)
        {
            throw new NotImplementedException();
        }

        public Dish GetDishById(int id)
        {
            return GetDishes()?.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Dish> GetDishes()
        {
            var json = File.ReadAllText(_path);
            System.Console.WriteLine(json);
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
            };

            var dishes = JsonSerializer.Deserialize<Dish[]>(json, options);
            return dishes;
        }

        public Dish UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}
