﻿using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModel[] modules)
        {
            foreach (var module in modules)
            {
                module.load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}