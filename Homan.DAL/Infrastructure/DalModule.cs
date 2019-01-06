using Homan.DAL.Repositories;
using Homan.DAL.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Homan.DAL.Infrastructure
{
    public static class DalModule
    {
        public static void RegisterDalModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<IHomeSpaceRepository, HomeSpaceRepository>();
            serviceCollection.AddTransient<IHomeSpaceItemRepository, HomeSpaceItemRepository>();
        }
    }
}