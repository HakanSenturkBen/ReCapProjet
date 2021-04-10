using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface IUsersService
    {
        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int userID);
        IResult Add(Users user);
        IResult Update(Users user);
        IResult Delete(Users user);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<Users> GetByEmail(string email);
    }
}
