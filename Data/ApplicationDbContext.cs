using HairDesginStudio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairDesginStudio.Data;

public class ApplicationDbContext : IdentityDbContext<AdvanceUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Operations>(entity =>
        {
            entity.HasKey(e => e.OperationId); // Primary key
        });
        modelBuilder.Entity<Workers>(entity =>
        {
            entity.HasKey(e => e.WorkerId); // Primary key
        });
        modelBuilder.Entity<WorkerOperations>(entity =>
        {
            entity.HasKey(e => e.WorkerId); // Primary key
        });
        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.CustomerId); // Primary key
        });
        modelBuilder.Entity<Reservations>(entity =>
        {
            entity.HasKey(e => e.ReservationId);
        });
        modelBuilder.Entity<WorkerShifts>(entity =>
        {
            entity.HasKey(e => e.WorkerId); // Primary key
        });
    }

    public DbSet<HairDesginStudio.Models.Operations> Operations { get; set; } = default!;
    public DbSet<HairDesginStudio.Models.Workers> Workers { get; set; } = default!;
    public DbSet<HairDesginStudio.Models.WorkerOperations> WorkerOperations { get; set; } = default!;
    public DbSet<HairDesginStudio.Models.Customers> Customers { get; set; } = default!;
    public DbSet<HairDesginStudio.Models.Reservations> Reservations { get; set; } = default!;
    public DbSet<HairDesginStudio.Models.WorkerShifts> WorkerShifts { get; set; } = default!;

}
