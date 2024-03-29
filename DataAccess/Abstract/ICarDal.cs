﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsbyColor(int id);
        List<CarDetailDto> GetCarDetailsbyBrand(int id);
        List<CarInfoDetail> GetCarDetailInfo(int id);
      


    }
}