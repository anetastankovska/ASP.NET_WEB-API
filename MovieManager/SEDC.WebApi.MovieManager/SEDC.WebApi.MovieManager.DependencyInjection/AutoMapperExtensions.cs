using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.MovieManager.Common.MappingHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DependencyInjection
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection RegisterAutoMapperDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MovieAutoMapper));
            return services;
        }
    }
}
