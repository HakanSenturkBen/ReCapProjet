using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Rentals : IEntity
    {
        private bool _available;
        public int RentID { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Available
        {
            get
            {
                return _available;
            }
            set
            {
                value = ((ReturnDate.Day + (ReturnDate.Month * 30)) - (RentDate.Day + (RentDate.Month * 30))) < 0;
                _available = value;
            }
        }
    }
}
