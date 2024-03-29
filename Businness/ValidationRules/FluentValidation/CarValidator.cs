﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThan(1500);
            RuleFor(p => p.DailyPrice).NotEmpty();
            //RuleFor(p => p.CarName).Must(StartWithA).WithMessage("Ürünler A harfi iel başlamalı");
        }
        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
