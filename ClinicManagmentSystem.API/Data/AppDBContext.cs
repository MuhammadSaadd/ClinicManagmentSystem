namespace ClinicManagmentSystem.API.Data;

public class AppDBContext : DbContext
{
    public DbSet<Clinic> Clinics => Set<Clinic>();
    public DbSet<Shift> Shifts => Set<Shift>();
    public DbSet<Physician> Physicians => Set<Physician>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<EpisodeVisit> EpisodeVisits => Set<EpisodeVisit>();


    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Clinic configurations
        modelBuilder.Entity<Clinic>()
            .ToTable("Clinics")
            .HasKey(c => c.Id);

        modelBuilder.Entity<Clinic>()
            .HasMany(c => c.Shifts) // one-to-many relationship with Shifts
            .WithOne(s => s.Clinic) // navigation property
            .HasForeignKey(s => s.ClinicId);

        modelBuilder.Entity<Clinic>()
            .HasIndex(c => c.Title)
            .IsUnique(true);
        // Physician configurations
        modelBuilder.Entity<Physician>()
            .ToTable("Physicians")
            .HasKey(p => p.Id);

        modelBuilder.Entity<Physician>()
            .HasMany(p => p.Shifts)
            .WithOne(s => s.Physician)
            .HasForeignKey(s => s.PhysicianId);

        modelBuilder.Entity<Physician>()
            .HasMany(p => p.Appointments)
            .WithOne(a => a.Physician)
            .HasForeignKey(a => a.PhysicianId)
            .OnDelete(DeleteBehavior.SetNull); ;

        modelBuilder.Entity<Physician>()
            .HasIndex(p => p.SSN)
            .IsUnique(true);
        // Shift configurations
        modelBuilder.Entity<Shift>()
            .ToTable("Shifts")
            .HasKey(s => s.Id);

        modelBuilder.Entity<Shift>()
            .HasOne(s => s.Clinic)
            .WithMany(c => c.Shifts)
            .HasForeignKey(s => s.ClinicId);

        modelBuilder.Entity<Shift>()
            .HasOne(s => s.Physician)
            .WithMany(p => p.Shifts)
            .HasForeignKey(s => s.PhysicianId);

        // Patient configurations
        modelBuilder.Entity<Patient>()
            .ToTable("Patients")
            .HasKey(p => p.Id);

        modelBuilder.Entity<Patient>()
            .HasMany(p => p.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.SetNull);

        // Appointments configurations
        modelBuilder.Entity<Appointment>()
            .ToTable("Appointments")
            .HasKey(p => p.Id);

        // Episode Visit configurations     
        modelBuilder.Entity<EpisodeVisit>()
            .ToTable("EpisodeVisits")
            .HasKey(ev => ev.Id);

        modelBuilder.Entity<EpisodeVisit>()
            .HasOne(ev => ev.Appointment)
            .WithOne(a => a.EpisodeVisit)
            .HasForeignKey<EpisodeVisit>(ev => ev.AppointmentId);
    }
}

