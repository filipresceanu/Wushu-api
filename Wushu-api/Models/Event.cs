using System.ComponentModel.DataAnnotations.Schema;

namespace Wushu_api.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Participant> Participants { get; set; }

       
    }
}
