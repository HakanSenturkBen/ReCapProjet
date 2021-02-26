using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ModelYear { get; set; }
    }
}