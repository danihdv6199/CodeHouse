using Bootcamp.Application.Contracts.Servicies;
using Bootcamp.Application.Servicies;
using Bootcamp.DataAccess;
using Bootcamp.DataAccess.Contracts;
using Bootcamp.DataAccess.Contracts.Repositories;
using Bootcamp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CrossCutting.Configuration
{
    public static class IoC
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(
                item => item.UseMySql(
                    mySqlConnectionStr,
                    ServerVersion.AutoDetect(mySqlConnectionStr)
                    )
                );

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
