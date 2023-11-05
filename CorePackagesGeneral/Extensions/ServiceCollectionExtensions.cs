using CorePackagesGeneral.DependencyResolvers;
using CorePackagesGeneral.IoC;
using CorePackagesGeneral.IoC.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackagesGeneral.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
    {
        foreach (var module in modules)
        {
            module.Load(serviceCollection);
        }
        return ServiceTool.Create(serviceCollection);

    }
}
