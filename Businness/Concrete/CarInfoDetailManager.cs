using Businness.Abstract;
using Businness.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    public class CarInfoDetailManager : ICarInfoDetailService
    {
        ICarInfoDetailDal _carInfoDetailDal;

        public CarInfoDetailManager(ICarInfoDetailDal carInfoDetailDal)
        {
            _carInfoDetailDal = carInfoDetailDal;
        }

        public IResult Add(CarInfoDetail car)
        {
            _carInfoDetailDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

       
        public IResult Delete(CarInfoDetail car)
        {
            _carInfoDetailDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarInfoDetail>> GetAll()
        {
            return new SuccessDataResult<List<CarInfoDetail>>(_carInfoDetailDal.GetAll() ,Messages.Listed);
        }

        public IResult Update(CarInfoDetail car)
        {
            _carInfoDetailDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
