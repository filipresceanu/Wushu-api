using Wushu_api.Models;

namespace Wushu_api.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Sex { get; set; }

        public int LessThanWeight { get; set; }

        public int GraterThanWeight { get; set; }



    }
}
