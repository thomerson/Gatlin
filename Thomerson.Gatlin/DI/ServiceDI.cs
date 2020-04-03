using Microsoft.Extensions.DependencyInjection;
using Thomerson.Gatlin.Contract;
using Thomerson.Gatlin.Repository;

namespace Thomerson.Gatlin.DI
{
    /// <summary>
    /// service DependencyInjection
    /// </summary>
    public class ServiceDI
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ITransientService, TransientService>();
            services.AddScoped<IUserService, UserRealize>();
            //services.AddSingleton<ISingletonService, SingletonService>();

            services.AddMvc();
        }
    }
}
