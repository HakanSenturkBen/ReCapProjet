using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Businness.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
        IResult Add(Customer user);
        IResult Update(Customer user);
        IResult Delete(Customer user);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<Customer> GetByEmail(string email);


    }
}
