using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Backend_MusicTime.Review.Domain.Model.Entities;
using System.Reflection.Emit;

namespace Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Puntuation> Puntuations { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Musician Context
        builder.Entity<Artist>().HasKey(p => p.Id);
        builder.Entity<Artist>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Artist>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });

        // Contract Context
        builder.Entity<Contract>().HasKey(p => p.Id);
        builder.Entity<Contract>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Contract>().OwnsOne(p => p.CustomerName,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("CustomerFirstName");
                n.Property(p => p.LastName).HasColumnName("CustomerLastName");
            });
        builder.Entity<Contract>().OwnsOne(p => p.MusicianName,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("MusicianFirstName");
                n.Property(p => p.LastName).HasColumnName("MusicianLastName");
            });
        builder.Entity<Contract>().OwnsOne(p => p.EventLocation,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("EventLocationStreet");
                a.Property(s => s.Number).HasColumnName("EventLocationNumber");
                a.Property(s => s.City).HasColumnName("EventLocationCity");
            });

        //Review Context
        builder.Entity<Comment>().HasKey(p => p.Id);
        builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comment>().OwnsOne(p => p.UserId,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Value).HasColumnName("UserId");
            });
        builder.Entity<Comment>().OwnsOne(p => p.BandId,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Value).HasColumnName("BandId");
            });
        builder.Entity<Puntuation>().HasKey(p => p.Id);
        builder.Entity<Puntuation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Puntuation>().OwnsOne(p => p.UserId,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Value).HasColumnName("UserId");
            });
        builder.Entity<Puntuation>().OwnsOne(p => p.BandId,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Value).HasColumnName("BandId");
            });
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}