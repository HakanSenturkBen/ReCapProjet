using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarInfoDetail : IDto, IEntity
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
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
