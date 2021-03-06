namespace MilkingPigeons.Models
{
    public class TeamChallenge
    {
        public int TeamChallengeId { get; set; }
        public int ChallengeId { get; set; }
        public int TeamId { get; set; }
        public Challenge Challenge { get; set; }
        public Team Team { get; set; }
    }
    public class teamChallengeJson
    {
        public int TeamChallengeId { get; set; }
        public string Name { get; set; }
    }
    public class AddTeamChallengeJson
    {
        public int TeamId { get; set; }
        public int Pin { get; set; }
    }
}