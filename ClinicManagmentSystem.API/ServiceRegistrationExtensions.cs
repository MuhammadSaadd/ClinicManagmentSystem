using Hangfire.SqlServer;

namespace ClinicManagmentSystem.API;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        // add the DbContext
        services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"))
        );

        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("SqlConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));

        services.AddHangfireServer();

        services.Configure<MongoDBContext>(configuration.GetSection("PrescriptionsConnection"));

        return services;
    }

    public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IClinicServices, ClinicServices>();
        services.AddScoped<IPhysicianServices, PhysicianServices>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IShiftServices, ShiftServices>();
        services.AddScoped<IPatientServices, PatientServices>();
        services.AddScoped<IPrescriptionServices, PrescriptionServices>();
        services.AddScoped<IAppointmentServices, AppointmentServices>();

        return services;
    }
}
