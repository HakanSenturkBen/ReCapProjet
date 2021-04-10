using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<List<Rentals>> GetById(int rentalID);
        IResult Add(Rentals rent);
        IResult Update(Rentals rent);
        IResult Delete(Rentals rent);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsCarId(int CarID);
    }
}
