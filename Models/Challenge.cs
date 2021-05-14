namespace MilkingPigeons.Models
{
    public class Challenge
    {
        public int ChallengeId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    public class ChallengeJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
