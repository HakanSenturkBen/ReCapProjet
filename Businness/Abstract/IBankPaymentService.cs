using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface IBankPaymentService
    {
        IDataResult<BankPaymentService> GetById(int BankID);
        IDataResult<List<BankPaymentService>> GetAll();
        IResult Add(BankPaymentService bankPayment);
        IResult Update(BankPaymentService bankPayment);
        IResult Delete(BankPaymentService bankPayment);
    }
}
