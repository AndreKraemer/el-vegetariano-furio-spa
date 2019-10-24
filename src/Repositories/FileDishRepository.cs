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
            var dishes = GetDishes()?.ToList() ?? new List<Dish>();
            if(dishes.Count == 0)
            {
                dish.Id = 1;
            }
            else
            {
                dish.Id = dishes.Max(x => x.Id) + 1;
            }
            dishes.Add(dish);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(dishes, options);
            File.WriteAllText(_path, json);
            return dish;
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
            var dishes = GetDishes();
            var dishToUpdate = dishes.SingleOrDefault(x => x.Id == dish.Id);
            dishToUpdate.Name = dish.Name;
            dishToUpdate.Price = dish.Price;
            dishToUpdate.Description = dish.Description;
            dishToUpdate.CategoryId = dish.CategoryId;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(dishes, options);
            File.WriteAllText(_path, json);
            return dish;
        }
    }
}
