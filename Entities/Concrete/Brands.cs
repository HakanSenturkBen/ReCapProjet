using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Brands : IEntity
    {
       
        public int BrandID { get; set; }
        public string BrandName { get; set; }
    }
}