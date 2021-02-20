using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carDal;

        public InMemoryCarDal()
        {
            _carDal = new List<Car>
            {
                new Car{CarID=1, BrandID=1, ColorID=1, CarName="Lamborghini Huracan", DailyPrice=750, Description="2300 cc V6 motor 4500Hp", ModelYear="2016"},
                new Car{CarID=2, BrandID=3, ColorID=2, CarName="Porsche 918 Spyder", DailyPrice=500, Description="2000 cc 4 silindir 2500Hp", ModelYear="2002"},
                new Car{CarID=3, BrandID=3, ColorID=3, CarName="Ferrari 458 ", DailyPrice=200, Description="2300 cc 4 silindir 1600 Hp", ModelYear="2014"},
                new Car{CarID=4, BrandID=2, ColorID=3, CarName="Bugatti Veyron", DailyPrice=300, Description="2300 cc 4 silindir 1600 Hp", ModelYear="2018"},
                new Car{CarID=5, BrandID=4, ColorID=2, CarName="Lotus Evija", DailyPrice=450, Description="2300 cc 4 silindir 1600 Hp", ModelYear="2018"},
                new Car{CarID=6, BrandID=1, ColorID=1, CarName="Dodge Charger", DailyPrice=100, Description="2300 cc 4 silindir 1600 Hp", ModelYear="2018"},

            };
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _carDal.SingleOrDefault(c => c.CarID == car.CarID);
            _carDal.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carDal;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int brandsId)
        {
            return _carDal.Where(c => c.BrandID == brandsId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }


        public void Update(Car car)
        {
            Car carToUpdate = _carDal.SingleOrDefault(c => c.CarID == car.CarID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}