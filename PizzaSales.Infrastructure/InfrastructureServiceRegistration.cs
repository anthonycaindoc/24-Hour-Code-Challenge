using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PizzaSales.Core.Contracts.Interfaces.Repositories;
using PizzaSales.Infrastructure.Configurations;
using PizzaSales.Infrastructure.Contexts;
using PizzaSales.Infrastructure.Repositories;


//using PizzaSales.Infrastructure.Repositories;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Reflection;
using System.Text;

namespace PizzaSales.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
        {
            host.UseSerilog(((ctx, lc) =>
            {
                lc.WriteTo.MSSqlServer(ctx.Configuration.GetConnectionString("EHRLICH_DB"),
                    new MSSqlServerSinkOptions()
                    {
                        TableName = "appLogs",
                        AutoCreateSqlTable = true,
                    }, restrictedToMinimumLevel: LogEventLevel.Warning);
            }));

            #region App Configurations
            services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
            #endregion

            #region Context/Repository Registration
            services.AddDbContext<PizzaDbContext>(db => db.UseSqlServer(configuration.GetConnectionString("EHRLICH_DB")), ServiceLifetime.Transient);

            services.AddTransient<IOrderRepository, OrderRepository>();
            #endregion

            #region Services Registration

            #endregion

            #region Token Configuration
            services.AddAuthentication(c =>
            {
                c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(c =>
            {
                c.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if (context.SecurityToken.Issuer == configuration.GetSection("TokenConfiguration:ISSUER").Value)
                        {
                            return Task.CompletedTask;
                        }
                        else
                        {
                            context.Fail("Missing or Invalid Bearer Token.");
                            context.Options.Challenge = "Missing or Invalid Bearer Token.";
                        }

                        return Task.CompletedTask;
                    }
                };
                c.SaveToken = true;
                c.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = configuration.GetSection("TokenConfiguration:ISSUER").Value,
                    ValidAudience = configuration.GetSection("TokenConfiguration:AUDIENCE").Value,
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("TokenConfiguration:SECRET_KEY").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = Convert.ToBoolean(configuration.GetSection("TokenConfiguration:VALIDATE_LIFETIME").Value),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorizationBuilder()
                .AddPolicy("APP-Only", policy => policy.RequireClaim("iss", "api.ehrlich.ph"));
            #endregion

            return services;
        }
    }
}
