using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int imageId);
        IResult Add(CarImages images);
        IResult Update(CarImages images);
        IResult Delete(CarImages images);
    }
}
