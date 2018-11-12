using Homan.BLL.Factories;
using Homan.BLL.Services;
using Homan.BLL.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace Homan.BLL.Infrastructure
{
    public static class BllModule
    {
        public static void RegisterBllModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IHomeSpaceService, HomeSpaceService>();
            serviceCollection.AddTransient<IHomeSpaceFactory, HomeSpaceFactory>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ITokenFactory, TokenFactory>();
        }
    }
}