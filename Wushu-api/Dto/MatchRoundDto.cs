namespace Wushu_api.Dto
{
    public class MatchRoundDto
    {
        public int MatchNumber { get; set; }

        public Guid MatchId { get; set; }
        public List<RoundRefereDto> RoundsRefere { get; set;}
    }
}
