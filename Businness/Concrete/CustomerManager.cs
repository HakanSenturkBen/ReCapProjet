using Businness.Abstract;
using Businness.Constant;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _custmerDal;

        public CustomerManager(ICustomerDal custmerDal)
        {
            _custmerDal = custmerDal;
        }

        public IResult Add(Customer user)
        {
            _custmerDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer user)
        {
            _custmerDal.Delete(user);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_custmerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Customer> GetByEmail(string email)
        {
            return new SuccessDataResult<Customer>(_custmerDal.Get(x => x.Email == email));
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_custmerDal.Get(x => x.Id== id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer user)
        {
            _custmerDal.Update(user);
            return new SuccessResult(Messages.Added);
        }
    }
}
