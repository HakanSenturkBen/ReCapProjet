using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarInfoDetail : EfEntityRepositoryBase<CarInfoDetail, RentaCarContext>, ICarInfoDetailDal
    {
        
    }
}
