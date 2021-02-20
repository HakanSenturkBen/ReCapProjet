using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from c in context.Car
                             join b in context.Brands
                             on c.BrandID equals b.BrandID
                             select new CarDetailDto
                             {
                                 CarID = c.CarID,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}

