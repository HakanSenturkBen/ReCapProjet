using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImagePath:IEntity
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public string CarImage { get; set; }
    }
}
