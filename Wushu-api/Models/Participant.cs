namespace Wushu_api.Models
{
    public class Participant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Club { get; set; }

        public DateTime BirthDay { get; set; }

        public string Sex { get; set; }

        public int CategoryWeight { get; set; }

        public Event Event { get; set; }
    }
}
