﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WushuParticipants.Models
{
    public class Round
    {
        [Key]
        public Guid Id { get; set; }

        public Guid MatchId { get; set; }

        public Match Match { get; set; }

        public int PointParticipantFirst { get; set; }

        public int PointParticipantSecond { get; set; }

        public Guid ParticipantWinnerId { get; set; }

        [ForeignKey("ParticipantWinnerId")]
        public Participant ParticipantWinner { get; set; }

    }
}
