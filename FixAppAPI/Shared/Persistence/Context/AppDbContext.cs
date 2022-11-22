using FixAppAPI.App.Domain.Models;
using FixAppAPI.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FixAppAPI.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Artifact> Artifacts { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.id);
        builder.Entity<User>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.name).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.lastName).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.cellphone).IsRequired().HasMaxLength(9);
        builder.Entity<User>().Property(p => p.password).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.email).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.address).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.rol).IsRequired().HasMaxLength(30);

        // Relationships
        builder.Entity<User>()
            .HasMany(p => p.Artifacts)
            .WithOne(p => p.user)
            .HasForeignKey(p => p.userId);
        builder.Entity<User>()
            .HasMany(p => p.Appointments)
            .WithOne(p => p.user)
            .HasForeignKey(p => p.userId);

        builder.Entity<Artifact>().ToTable("Artifacts");
        builder.Entity<Artifact>().HasKey(p => p.id);
        builder.Entity<Artifact>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Artifact>().Property(p => p.name).IsRequired().HasMaxLength(50);
        builder.Entity<Artifact>().Property(p => p.url).HasMaxLength(120);
        
        // Users
            
        // Constraints
        builder.Entity<Appointment>().ToTable("Appointments");
        builder.Entity<Appointment>().HasKey(p => p.id);
        builder.Entity<Appointment>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}