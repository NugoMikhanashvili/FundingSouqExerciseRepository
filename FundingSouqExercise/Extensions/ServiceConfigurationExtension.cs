using FundingSouqExercise.Services.Abstraction;
using FundingSouqExercise.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Extensions
{
    public static class ServiceConfigurationExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClientAccountService, ClientAccountService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
