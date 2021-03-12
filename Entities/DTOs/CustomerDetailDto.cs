using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto : IDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
    }
}
