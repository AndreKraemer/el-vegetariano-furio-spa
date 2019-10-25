using System.Collections.Generic;
using System.Linq;
using ElVegetarianoFurio.Models;
using Microsoft.EntityFrameworkCore;

namespace ElVegetarianoFurio.Repositories
{
    public class EfDishRepository : IDishRepository
    {

        private readonly VegiContext _vegiContext;

        public EfDishRepository(VegiContext vegiContext)
        {
            _vegiContext = vegiContext;
        }

        public IEnumerable<Dish> GetDishes()
        {
            return _vegiContext.Dishes.AsNoTracking().ToList();
        }

        public Dish GetDishById(int id)
        {
            return _vegiContext.Dishes.Find(id);
        }

        public Dish CreateDish(Dish dish)
        {
            _vegiContext.Dishes.Add(dish);
            _vegiContext.SaveChanges();
            return dish;
        }

        public Dish UpdateDish(Dish dish)
        {
            var dishToUpdate = GetDishById(dish.Id);
            dishToUpdate.Name = dish.Name;
            dishToUpdate.Description = dish.Description;
            dishToUpdate.Price = dish.Price;
            dishToUpdate.CategoryId = dish.CategoryId;

            _vegiContext.SaveChanges();
            return dishToUpdate;
        }

        public void DeleteDish(int id)
        {
            var dish = GetDishById(id);
            _vegiContext.Dishes.Remove(dish);

            _vegiContext.SaveChanges();
        }
    }
}