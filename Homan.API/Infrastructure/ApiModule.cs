using Homan.API.Factories;
using Homan.API.Factories.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Homan.API.Infrastructure
{
    public static class ApiModule
    {
        public static void RegisterApiModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHomeSpaceWebModelFactory, HomeSpaceWebModelFactory>();
        }
    }
}