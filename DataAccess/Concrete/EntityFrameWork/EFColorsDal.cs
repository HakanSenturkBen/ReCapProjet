﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFColorsDal : EfEntityRepositoryBase<Color, RentaCarContext>, IColorDal
    {

    }
}