using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EFBrandsDal : EfEntityRepositoryBase<Brands, RentaCarContext>, IBrandsDal
    {

    }
}