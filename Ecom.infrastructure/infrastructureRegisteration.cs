using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using Ecom.infrastructure.Repositories;
using Ecom.infrastructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure
{
    public static class infrastructureRegisteration
    {
        public static IServiceCollection infrastructureConfigration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            // apply unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IImageManagementService,ImageManagementService>();

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));
            // apply DbContext
            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("EcomDatabase"));
            });
            return services;
        }

    }
}
