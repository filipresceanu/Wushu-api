using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wushu_api.Models
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime dateTime { get; set; }
        public Guid CompetitorFirstId { get; set; }

        [ForeignKey("CompetitorFirstId")]
        public Participant CompetitorFirst { get; set; }

        public Guid CompetitorSecondId { get; set; }

        [ForeignKey("CompetitorSecondId")]
        public Participant CompetitorSecond { get; set; }

        public Guid? ParticipantWinnerId { get; set; }

        [ForeignKey("ParticipantWinnerId")]
        public Participant? ParticipantWinner { get; set; }
        public ICollection<Round>Rounds { get; set; }

        [ForeignKey("UserId")]

        public User? User { get; set; }

        public string? UserId { get; set; }

    }
}
