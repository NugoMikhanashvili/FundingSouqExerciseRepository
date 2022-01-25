using FundingSouqExercise.Data.Abstraction;
using FundingSouqExercise.Data.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Extensions
{
    public static class RepositoryConfigurationExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISearchedParameterRepository, SearchedParameterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
