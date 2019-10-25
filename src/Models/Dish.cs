using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ElVegetarianoFurio.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
