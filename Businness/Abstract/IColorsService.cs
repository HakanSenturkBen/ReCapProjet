using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface IColorsService
    {
        IDataResult<List<Colors>> GetAll();
        IDataResult<Colors> GetById(int colorID);
        IResult Add(Colors color);
        IResult Update(Colors color);
        IResult Delete(Colors color);
    }
}
