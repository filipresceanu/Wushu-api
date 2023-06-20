namespace Wushu_api.Models
{
    public class MatchDistributions
    {
        public Guid Id { get; set; }

        public ICollection<Match>Matches { get; set; }
    }
}
