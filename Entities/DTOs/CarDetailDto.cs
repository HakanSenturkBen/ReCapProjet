using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string CarImage { get; set; }
        public string Manifacturer { get; set; }
        public string Production { get; set; }
        public string Assembly { get; set; }
        public string Designer { get; set; }
        public string Class { get; set; }
        public string BodyStyle { get; set; }
        public string Engine { get; set; }
        public string PowerOut { get; set; }
        public string Transmission { get; set; }

    }
}