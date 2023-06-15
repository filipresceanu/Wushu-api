using System.ComponentModel.DataAnnotations.Schema;

namespace Wushu_api.Models
{
    public class Match
    {
        public Guid Id { get; set; }

        public int MatchNumber { get;set; }
      

        public Guid CompetitorFirstId { get; set; }

      
       
        public Guid CompetitorSecondId { get; set; }

        public virtual Participant Participant { get; set; }


    }
}
