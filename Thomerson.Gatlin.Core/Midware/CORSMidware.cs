using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Thomerson.Gatlin.Core.Midware
{
    /// <summary>
    /// 跨域设置
    /// </summary>
    public static class CORSMidware
    {
        public static readonly string PolicyName = "AppDomain";


        public static IServiceCollection AddCorsMidware(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, builder =>
                {
                    builder
                    //.WithOrigins("http://127.0.0.1:65356", "http://localhost:65356")
                    .AllowAnyOrigin() // Allow access to any source from the host
                    .AllowAnyMethod()        // Ensures that the policy allows any method
                    .AllowAnyHeader()        // Ensures that the policy allows any header
                    .AllowCredentials();     // Specify the processing of cookie
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCORSMidware(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);//必须位于UserMvc之前 
            return app;
        }
    }
}
