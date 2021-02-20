using Core.Utilities.Result;
using Entities.Concrete;
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
        IResult Update(Users brand);
        IResult Delete(Users brand);
    }
}
