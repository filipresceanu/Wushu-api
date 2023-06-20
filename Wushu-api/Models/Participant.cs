using System.ComponentModel.DataAnnotations.Schema;

namespace Wushu_api.Models
{
    public class Participant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Club { get; set; }

        public DateTime BirthDay { get; set; }

        public string? Sex { get; set; }

        public int CategoryWeight { get; set; }

        public string? Color { get; set; }

       
        public Event Event { get; set; }

        public Category? Category { get; set; }

        public int calculateAge(DateTime birthDay)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(birthDay).Ticks).Year - 1;
            return Years;

        }

        [InverseProperty("CompetitorFirst")]
        public  ICollection<Match> MatchesAsFirstCompetitor { get; set; }

        [InverseProperty("CompetitorSecond")]
        public ICollection<Match> MatchesAsSecondCompetitor { get; set; }

        
    }
}
