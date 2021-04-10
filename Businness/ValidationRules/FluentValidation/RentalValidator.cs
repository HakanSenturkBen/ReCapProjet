using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.ValidationRules.FluentValidation
{
   public class RentalValidator : AbstractValidator<Rentals>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).Must(validRentDate).WithMessage("Geçmişe dönük gün seçemezsiniz :)");
        }

        private bool validRentDate(DateTime arg)
        {
           
            DateTime today = DateTime.Today;
            int hakan = DateTime.Compare(arg, today);
            bool result = !(DateTime.Compare(arg, today) <0);

            return result;
            
        }
      
    }
}
