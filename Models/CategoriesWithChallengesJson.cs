using System.Collections.Generic;
namespace MilkingPigeons.Models
{
    public class CategoriesWithChallengesJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ChallengeJson> Ch { get; set; }
    }
}
