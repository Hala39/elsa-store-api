using ELSAPI;
using ELSAPI.Helpers;
using ELSAPI.Interfaces;
using ELSAPI.Repositories;
using ELSAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IBasketRepo, BasketRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}