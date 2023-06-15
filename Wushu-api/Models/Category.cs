namespace Wushu_api.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Sex { get; set; }

        public int Weight { get; set; }

        public int LessThanAge { get; set; }

        public int GraterThanAge { get; set; }

        public ICollection<Participant> Participants { get; set; }
    }
}
