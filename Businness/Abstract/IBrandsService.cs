
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface IBrandsService
    {
        IDataResult<List<Brands>> GetAll();
        IDataResult<Brands> GetById(int brandID);
        IResult Add(Brands brand);
        IResult Update(Brands brand);
        IResult Delete(Brands brand);
    }
}
