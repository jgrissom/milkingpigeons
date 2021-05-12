using System.Collections.Generic;
namespace MilkingPigeons.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Challenge> Challenges { get; set; }
    }
    public class CategoryJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
