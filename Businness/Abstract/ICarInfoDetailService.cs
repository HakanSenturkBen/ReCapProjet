using Core.Utilities.Result;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface ICarInfoDetailService
    {

        IResult Add(CarInfoDetail car);
        IResult Update(CarInfoDetail car);
        IResult Delete(CarInfoDetail car);
        IDataResult<List<CarInfoDetail>> GetAll();
    }
}
