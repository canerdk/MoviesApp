using Microsoft.Extensions.DependencyInjection;
using Movie.Business.Abstract;
using Movie.Business.Concrete;
using Movie.DataAccess.Abstract;
using Movie.DataAccess.Concrete;

namespace Movie.Business.DependencyResolver
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IMovieManager, MovieManager>();
            services.AddScoped<IMovieDAL, MovieDAL>();
            return services;
        }
    }
}
