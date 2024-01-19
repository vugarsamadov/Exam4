using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Business.MapperProfiles;
using Exam4.Business.Services;
using Exam4.Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Exam4.Business
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services,IWebHostEnvironment env)
        {
            services.AddScoped<IInstructorService, InstructorService>();

            services.AddAutoMapper(options=>
            {
                options.AddProfile(new Profiles(env));
            });



            return services;
        }

    }
}
