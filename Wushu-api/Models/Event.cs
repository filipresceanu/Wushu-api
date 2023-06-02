namespace Wushu_api.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
