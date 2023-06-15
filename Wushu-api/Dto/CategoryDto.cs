using Wushu_api.Models;

namespace Wushu_api.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Sex { get; set; }

        public int Weight { get; set; }

        public int LessThanAge { get; set; }

        public int GraterThanAge { get; set; }

        
    }
}
