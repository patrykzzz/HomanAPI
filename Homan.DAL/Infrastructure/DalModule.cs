using Homan.DAL.Repositories;
using Homan.DAL.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Homan.DAL.Infrastructure
{
    public static class DalModule
    {
        public static void RegisterDalModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHomeSpaceRepository, HomeSpaceRepository>();
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}