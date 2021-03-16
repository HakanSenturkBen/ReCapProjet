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
                var result = from car in context.Car
                             join brand in context.Brands on car.BrandID equals brand.BrandID
                             join color in context.Colors on car.ColorID equals color.ColorId
                             join image in context.CarImage on car.CarID equals image.CarID
                             select new CarDetailDto
                             {
                                 CarID = car.CarID,
                                 BrandName = brand.BrandName + " " + car.CarName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 CarImage=image.CarImage
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsbyBrand(int id)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from car in context.Car
                             join brand in context.Brands on car.BrandID equals brand.BrandID
                             join color in context.Colors on car.ColorID equals color.ColorId
                             where car.BrandID == id
                             select new CarDetailDto
                             {
                                 CarID = car.CarID,
                                 BrandName = brand.BrandName + " " + car.CarName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };

                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarDetailsbyColor(int id)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from car in context.Car
                             join brand in context.Brands on car.BrandID equals brand.BrandID
                             join color in context.Colors on car.ColorID equals color.ColorId
                             where car.ColorID== id
                             select new CarDetailDto
                             {
                                 CarID = car.CarID,
                                 BrandName = brand.BrandName + " " + car.CarName,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description
                             };
                return result.ToList();
            }
        }
    }
}
