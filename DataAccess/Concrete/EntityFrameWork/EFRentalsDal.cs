using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFRentalsDal : EfEntityRepositoryBase<Rentals, RentaCarContext>, IRentalsDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Car on r.CarId equals c.CarID
                             join u in context.Users on r.CustomerId equals u.UserID
                             join b in context.Brands on c.BrandID equals b.BrandID
                             join color in context.Colors on c.ColorID equals color.ColorId
                             join cos in context.Customers on u.UserID equals cos.userID

                             select new RentalDetailDto
                             {
                                 RentalID = r.RentID,
                                 CustomerName = u.FirstName + u.LastName,
                                 CarBrand = b.BrandName,
                                 CarName = c.CarName,
                                 CompanyName = cos.CompanyName,
                                 CarColor = color.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Totaldebt = ((r.ReturnDate.Day + (r.ReturnDate.Month * 30)) - (r.RentDate.Day + (r.RentDate.Month * 30))) * c.DailyPrice,
                                 checkReturn = ((r.ReturnDate.Day + (r.ReturnDate.Month * 30)) - (r.RentDate.Day + (r.RentDate.Month * 30))) > 0
                             };

                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetailsCarId(int CarID)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Car on r.CarId equals c.CarID
                             join u in context.Users on r.CustomerId equals u.UserID
                             join b in context.Brands on c.BrandID equals b.BrandID
                             join color in context.Colors on c.ColorID equals color.ColorId
                             join cos in context.Customers on u.UserID equals cos.userID

                             where c.CarID==CarID
                             select new RentalDetailDto
                             {
                                 RentalID = r.RentID,
                                 CustomerName = u.FirstName + u.LastName,
                                 CarBrand = b.BrandName,
                                 CarName = c.CarName,
                                 CompanyName = cos.CompanyName,
                                 CarColor = color.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 Totaldebt = ((r.ReturnDate.Day + (r.ReturnDate.Month * 30)) - (r.RentDate.Day + (r.RentDate.Month * 30))) * c.DailyPrice,
                                 checkReturn = ((r.ReturnDate.Day + (r.ReturnDate.Month * 30)) - (r.RentDate.Day + (r.RentDate.Month * 30))) > 0
                             };

                return result.ToList();
            }
        }
    }
}