using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.MovieManager.DataAccess;
using SEDC.WebApi.MovieManager.DataAccess.Repositories;
using SEDC.WebApi.MovieManager.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.MovieManager.DependencyInjection
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient <IRepository<Movie>, MovieRepository>();
            return services;
        }
    }
}
