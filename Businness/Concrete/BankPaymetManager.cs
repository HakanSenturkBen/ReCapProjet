﻿using Businness.Abstract;
using Businness.Constant;
using Businness.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    public class BankPaymetManager : IBankPaymentService
    {
        IBankPaymentDal _bankPaymentDal;

        public BankPaymetManager(IBankPaymentDal bankPaymentDal)
        {
            _bankPaymentDal = bankPaymentDal;
        }
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(BankPaymentService bankPayment)
        {
            //IResult result = BusinessRules.Run(ValidCard(bankPayment));
            //if (result != null)
            //{
            //    return result;
            //}
            _bankPaymentDal.Add(bankPayment);
            return new SuccessResult(Messages.PaymentComplete);
        }

        private IResult ValidCard(BankPaymentService bankPayment)
        {
            var result = Utilities.ValidCard(bankPayment.CreditCardNumber);
            if (!result)
            {
                return new ErrorResult(Messages.invalidCard);
            }
            return new SuccessResult();
            
        }

        public IResult Delete(BankPaymentService bankPayment)
        {
            _bankPaymentDal.Delete(bankPayment);
            return new SuccessResult();
        }

        public IDataResult<List<BankPaymentService>> GetAll()
        {
            return new SuccessDataResult<List<BankPaymentService>>(_bankPaymentDal.GetAll());
        }

        public IDataResult<BankPaymentService> GetById(int BankID)
        {
            return new SuccessDataResult<BankPaymentService>(_bankPaymentDal.Get(x => x.BankId == BankID));
        }

        
        public IResult Update(BankPaymentService bankPayment)
        {
            _bankPaymentDal.Update(bankPayment);
            return new SuccessResult();
        }
    }
}
