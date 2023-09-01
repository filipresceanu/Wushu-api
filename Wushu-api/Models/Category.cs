﻿namespace Wushu_api.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Sex { get; set; }

        public int LessThanWeight { get; set; }

        public int GraterThanWeight { get; set; }


        public ICollection<Participant> Participants { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get;set; } 

        public Guid AgeCategoryId { get; set; }
        public AgeCategory AgeCategory { get; set; }
    }
}
