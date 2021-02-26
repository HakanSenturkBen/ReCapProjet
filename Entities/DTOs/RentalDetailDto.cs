using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto

    {
        public int RentalID { get; set; }
        public string CustomerName { get; set; }
        public string CarBrand { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public string CarColor { get; set; }
        public string ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal Totaldebt { get; set; }

        public override string ToString() => $"{CustomerName} {CarBrand} {CarName} {CarColor} {ModelYear} {Totaldebt}";
    }
}