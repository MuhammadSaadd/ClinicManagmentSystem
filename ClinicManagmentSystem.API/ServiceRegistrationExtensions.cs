﻿namespace ClinicManagmentSystem.API;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IClinicServices, ClinicServices>();
        services.AddScoped<IPhysicianServices, PhysicianServices>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }

    public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        // add the DbContext
        services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        return services;
    }
}
