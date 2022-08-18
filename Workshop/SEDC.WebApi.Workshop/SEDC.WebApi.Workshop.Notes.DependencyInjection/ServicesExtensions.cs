using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.Workshop.Notes.Services;
using SEDC.WebApi.Workshop.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DependencyInjection
{
    public static class ServicesExtensions
    {

            public static IServiceCollection RegisterServicesDependencies
                (this IServiceCollection services)
            {
                services.AddTransient <INoteService, NoteService>();

                return services;
            }
    }
}
