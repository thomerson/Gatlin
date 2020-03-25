using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thomerson.Gatlin.Core.Midware
{
    public static class JWTAuthenticationMidware
    {
        public static IServiceCollection AddJWTAuthenticationMidware(this IServiceCollection services)
        {
            //添加jwt验证：
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ClockSkew = TimeSpan.FromSeconds(30),  //过期时间 30Min
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = AppCommon.Domain,//Audience
                        ValidIssuer = AppCommon.Domain,//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppCommon.SecurityKey))//拿到SecurityKey
                    };
                });

            return services;
        }
    }
}
