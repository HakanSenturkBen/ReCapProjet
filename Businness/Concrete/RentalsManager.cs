using Businness.Abstract;
using Businness.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IDataResult<Rentals> GetById(int rentalID)
        {
            return new SuccessDataResult<Rentals>(_rentalsDal.Get(x => x.RentID == rentalID));
        }

        public IResult Update(Rentals rent)
        {
            _rentalsDal.Update(rent);
            return new SuccessResult(Messages.Updated);
        }
    }
}
