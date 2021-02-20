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
    public class ColorsManager : IColorsService
    {
        IColorsDal _colorDal;

        public ColorsManager(IColorsDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Colors color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Colors color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Colors>> GetAll()
        {
            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Colors> GetById(int colorID)
        {
            return new SuccessDataResult<Colors>(_colorDal.Get(x => x.ColorId == colorID));
        }

        public IResult Update(Colors color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}
