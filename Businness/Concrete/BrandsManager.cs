using Businness.Abstract;
using Businness.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Businness.Concrete
{
    public class BrandsManager : IBrandsService
    {
        IBrandsDal _brandsDal;

        public BrandsManager(IBrandsDal brandsDal)
        {
            _brandsDal = brandsDal;
        }

        public IResult Add(Brands brand)
        {
            _brandsDal.Add(brand);
            return new SuccessResult(Messages.Added);
            
        }

        public IResult Delete(Brands brand)
        {
            _brandsDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brands>> GetAll()
        {
            return new SuccessDataResult<List<Brands>>(_brandsDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Brands> GetById(int brandID)
        {
            return new SuccessDataResult<Brands>(_brandsDal.Get(x => x.BrandID == brandID));
        }

        public IResult Update(Brands brand)
        {
            _brandsDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }

        
        
    }
}
