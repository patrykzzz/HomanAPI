using System.Runtime.CompilerServices;
using Homan.BLL.Services;
using Homan.BLL.Services.Abstract;
using Homan.BLL.Utilities;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("Homan.BLL.Tests")]
namespace Homan.BLL.Infrastructure
{
    public static class BllModule
    {
        public static void RegisterBllModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<HomeSpaceService>();
            serviceCollection.AddTransient<IHomeSpaceItemService, HomeSpaceItemService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ITokenFactory, TokenFactory>();
            serviceCollection.AddTransient<IHomeSpaceService, HomeSpaceServiceCacheDecorator>();
        }
    }
}