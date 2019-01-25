using System.Runtime.CompilerServices;
using Homan.BLL.ChainOfResponsibility;
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
            serviceCollection.AddTransient<IServicesFacade, ServicesFacade>();

            // Chain of responsibility registration
            serviceCollection.AddTransient<RefreshHomeSpaceCacheHandler>();

            serviceCollection.AddTransient<DeleteHomeSpaceItemHandler, DeleteHomeSpaceItemFromDatabaseHandler>(cfg =>
                new DeleteHomeSpaceItemFromDatabaseHandler(cfg.GetService<IHomeSpaceItemService>())
                {
                    Successor = cfg.GetService<RefreshHomeSpaceCacheHandler>()
                });
        }
    }
}