﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wushu_api.Models
{
    public class Round
    {
        [Key]
        public Guid Id { get; set; }

        

        public Match Match { get; set; }

        public int PointParticipantFirst { get; set; }

        public int PointParticipantSecond { get; set; }

       


    }
}