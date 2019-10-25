using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElVegetarianoFurio.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElVegetarianoFurio.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var vegiContext = new VegiContext(
                serviceProvider.GetRequiredService<DbContextOptions<VegiContext>>()))
            {
                if (vegiContext.Dishes.Any())
                {
                    return;
                }

                var categoriesRepository =
                    new FileCategoryRepository(serviceProvider.GetRequiredService<IWebHostEnvironment>());

                var categories = categoriesRepository.GetCategories().ToList();
                categories.ForEach(x =>
                {
                    x.Id = 0;
                    foreach (var dish in x.Dishes)
                    {
                        dish.Id = 0;
                        dish.CategoryId = 0;
                    }
                });

                vegiContext.Categories.AddRange(categories);
                vegiContext.SaveChanges();

            }
        }
    }
}
