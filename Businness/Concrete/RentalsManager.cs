﻿using Businness.Abstract;
using Businness.Constant;
using Businness.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;

        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rentals rent)
        {
            if (rent.ReturnDate==null)
            {
                return new ErrorResult(Messages.Rented);
            }
            _rentalsDal.Add(rent);
            return new SuccessResult(Messages.RentOk);
           
        }

        public IResult Delete(Rentals rent)
        {
            _rentalsDal.Delete(rent);
            return new SuccessResult(Messages.Deleted);

        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Rentals>> GetById(int carID)
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(x => x.CarId == carID));
        }


        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsCarId(int CarID)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalsDal.GetRentalDetailsCarId(CarID));
        }

        public IResult Update(Rentals rent)
        {
            _rentalsDal.Update(rent);
            return new SuccessResult(Messages.Updated);
        }

      
    }
}
