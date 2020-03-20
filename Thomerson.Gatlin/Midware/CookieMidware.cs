using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Thomerson.Gatlin.Midware
{
    public static class CookieMidware
    {
        public static IServiceCollection AddCookieMidware(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            return services;
        }

        public static IApplicationBuilder UseCookieMidware(this IApplicationBuilder app)
        {
            app.UseCookiePolicy();
            return app;
        }
    }
}
