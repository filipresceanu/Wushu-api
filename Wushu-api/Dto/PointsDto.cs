﻿namespace Wushu_api.Dto
{
    public class PointsDto
    {
        public int PointsFirstParticipant { get; set; }

        public int PointsSecondParticipant { get; set; }

        public Guid MatchId { get; set; }
    }
}