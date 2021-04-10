using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFUsersDal : EfEntityRepositoryBase<Users, RentaCarContext>, IUsersDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from x in context.Customers
                             join y in context.Users on x.Id equals y.UserID
                             select new CustomerDetailDto
                             {
                                 id = x.Id,
                                 name = y.FirstName + " " + y.LastName,
                                 company = x.FirstName + " "+x.LastName
                             };
                return result.ToList();
            }
        }
    }
}

