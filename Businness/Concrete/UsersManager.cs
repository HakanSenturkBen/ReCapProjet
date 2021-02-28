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
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(Users user)
        {
            _usersDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Users user)
        {
            _usersDal.Delete(user);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Users>> GetAll()
        {
            if (DateTime.Now.Hour>22|| DateTime.Now.Hour <8)
            {
                return new ErrorDataResult<List<Users>>(_usersDal.GetAll() ,Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Users> GetById(int userID)
        {
            return new SuccessDataResult<Users>(_usersDal.Get(x => x.UserID == userID));
        }

        public IResult Update(Users user)
        {
            _usersDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        
    }
}
