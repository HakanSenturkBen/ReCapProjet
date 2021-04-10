using Core.Utilities;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.ValidationRules.FluentValidation
{
    public class PaymentValidator:AbstractValidator<BankPaymentService>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.CreditCardNumber).Length(16).WithMessage("Kart numarasını 16 hane olarak tam yazınız lütfen");
            RuleFor(p => p.CreditCardNumber).Must(validCardNumber).WithMessage("Geçersiz kart numarası");
            RuleFor(p => p.TransactionAmount).GreaterThan(1000).WithMessage("Kira bedeli hatalı");
        }

        private bool validCardNumber(string arg)
        {
            if(arg.Length==16)  return Utilities.ValidCard(arg);
            return true;
        }
    }
}
