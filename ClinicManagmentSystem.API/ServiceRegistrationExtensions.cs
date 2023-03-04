using Hangfire;

namespace ClinicManagmentSystem.API;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        // add the DbContext
        services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ClinicsConnection")));

        services.AddHangfire(hangfire =>
            hangfire.UseSqlServerStorage(configuration.GetConnectionString("ClinicsConnection")));

        services.Configure<MongoDBContext>(configuration.GetSection("PrescriptionsConnection"));

        return services;
    }

    public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IClinicServices, ClinicServices>();
        services.AddScoped<IPhysicianServices, PhysicianServices>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IShiftServices, ShiftServices>();
        services.AddSingleton<IPrescriptionServices, PrescriptionServices>();

        return services;
    }
}
