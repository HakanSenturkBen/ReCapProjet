using Businness.Abstract;
using Businness.Constant;
using Core.Utilities.Result;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Core.Utilities.Business;

namespace Businness.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        const string path = "Pictures";
        ICarImagesDal _carImageDal;

        public CarImagesManager(ICarImagesDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(CarImages images)
        {
            //Resimler projeniz içerisinde bir klasörde tutulacaktır.
            //Bir arabanın en fazla 5 resmi olabilir.
            BusinessRules.Run(CheckDirectoryExistOrNot(path),CheckImageCount(images.CarId));

            //Resimler yüklendiği isimle değil, kendi vereceğiniz GUID ile dosyalanacaktır.
            images.ImagePath =path+"\\"+Guid.NewGuid().ToString();

            //Resmin eklendiği tarih sistem tarafından atanacaktır.
             images.DateTime = DateTime.Now;

            _carImageDal.Add(images);
            return new SuccessResult(Messages.Added);
        }

        private IResult CheckDirectoryExistOrNot(string path)
        {
            if (Directory.Exists(path))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.DirectoryNotExists);
        }

        private  IResult CheckImageCount(int carId)
        {
            int result = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageCountOverflow);
            }
            return new SuccessResult();
        }


        public IResult Delete(CarImages images)
        {
            _carImageDal.Delete(images);
            return new SuccessResult(Messages.Deleted);
            
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            //eğer arabaya ait resim eklenmemiş ise şirket logosu araç resmi olsun
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImages> GetById(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.ImageId == imageId), Messages.Listed);
        }

        public IResult Update(CarImages images)
        {
            _carImageDal.Update(images);
            return new SuccessResult(Messages.Updated);

        }
    }
}
