using System.Collections.Generic;

namespace ElVegetarianoFurio.Models
{
    public class Category
    {
        public Category()
        {
            Dishes = new HashSet<Dish>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}