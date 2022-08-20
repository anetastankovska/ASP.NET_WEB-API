using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.MovieManager.Services;
using SEDC.WebApi.MovieManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterServicesDependencies
                (this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();

            return services;
        }


    }
}
