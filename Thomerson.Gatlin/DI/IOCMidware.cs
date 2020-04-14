using Microsoft.Extensions.DependencyInjection;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Repository;

namespace Thomerson.Gatlin
{
    /// <summary>
    /// service DependencyInjection
    /// </summary>
    public static class IOCMidware
    {
        public static IServiceCollection AddIOCMidware(this IServiceCollection services)
        {
            //services.AddTransient<ITransientService, TransientService>();
            services.AddScoped<IUserService, UserRealize>();
            //services.AddSingleton<ISingletonService, SingletonService>();

            return services;
        }
    }
}
