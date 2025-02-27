using GenericRepository.Business.Services.Abstract;
using GenericRepository.Business.Services.Concrete;
using GenericRepository.DataAccess.Abstract;
using GenericRepository.DataAccess.Concrete.EntityFramework;
using GenericRepository.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;

namespace GenericRepository.Business.DependencyResolvers.DependencyInjection
{
    public static class DependencyContainer
    {
        public static void DependencyService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IWarehouseDal, WarehouseDal>();
            services.AddScoped<IWarehouseService, WarehouseManager>();
        }
    }
}
