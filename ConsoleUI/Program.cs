using Businness.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Car car = new Car { BrandID = 2, 
                                            CarName = "CakaCulko", 
                                            ColorID = 4, 
                                            DailyPrice = 1750, 
                                            Description = "Havalarda soğudu", 
                                            ModelYear = "2021" };

            AracEkle(car);
            CarTest();
        }

        private static void AracEkle(Car car)
        {
            EfEntityRepositoryBase<Car,RentaCarContext > temel = new EfEntityRepositoryBase<Car, RentaCarContext>();
            temel.Add(car);
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var cars in result.Data)
                {
                    Console.WriteLine("{0,20} {1,-20} {2}", cars.BrandName, cars.CarName, (cars.BrandName == "Bugatti" ? $"işte bu =>{ cars.CarName}" : "Ohbe"));
                }
            }

        }
    }
}
