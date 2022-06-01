using CentiroAssignment.Data;
using CentiroAssignment.Data.Repositories.OrderRepository;
using CentiroAssignment.Services.Features;
using CentiroAssignment.Services.Features.CSV_Files;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CentiroAssignment.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Order Services
            services.AddScoped<IOrderRepository, OrderRepository>();
            
            services.AddScoped<IOrderService, OrderService>();

            // CSV File Servive
            services.AddScoped<ICSVFileService, CSVFileService>();

            //Mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Data Access

            services.AddDataServices(configuration);

            return services;
        }
    }
}
