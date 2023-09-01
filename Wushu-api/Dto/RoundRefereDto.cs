namespace Wushu_api.Dto
{
    public class RoundRefereDto
    {
        public int RoundNumber { get; set; }

        public Guid RoundId { get; set; }
        public string FirstParticipantName { get; set; }
        public string SecondParticipantName { get; set;}

        public int FirstParticipantPoints { get; set; }

        public int SecondParticipantPoints { get; set;}
    }
}
