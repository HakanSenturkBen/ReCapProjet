using Core.Entities;

namespace Entities.Concrete
{
    public class Customers : IEntity
    {

        public int userID { get; set; }
        public string CompanyName { get; set; }
    }
}