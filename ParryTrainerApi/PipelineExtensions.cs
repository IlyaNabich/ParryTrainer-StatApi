using Application.Auth;
using Application.Services;
using Core.Abstractions;
using Core.Interfaces;
using DataAccess;
using DataAccess.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ParryTrainerApi;

public static class PipelineExtensions
{
    extension(IServiceCollection services)
    {
        public void AddApplicationServices(IConfiguration configuration)
        {
            services
                .AddConfigurations(configuration)
                .AddFrameworkServices()
                .AddServices()
                .AddDatabase(configuration)
                .AddProviders()
                .AddRepositories();
        }

        private IServiceCollection AddConfigurations(IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            return services;
        }

        private IServiceCollection AddFrameworkServices()
        {
            services
                .AddSwaggerGen()
                .AddEndpointsApiExplorer()
                .AddControllers();
            return services;
        }

        private IServiceCollection AddDatabase(IConfiguration configuration)
        {
            services.AddDbContext<ParryTrainerDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(ParryTrainerDbContext)));
            });
            return services;
        }

        private IServiceCollection AddRepositories()
        {
            return services
                .AddScoped<IProfilesRepository, ProfilesRepository>()
                .AddScoped<IStatsRepository, StatsRepository>()
                .AddScoped<IUsersRepository, UsersRepository>();
        }

        private IServiceCollection AddServices()
        {
            return services
                .AddScoped<IProfilesService, ProfilesService>()
                .AddScoped<IStatsService, StatsService>()
                .AddScoped<IUserService, UsersService>();
        }

        private IServiceCollection AddProviders()
        {
            return services
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}