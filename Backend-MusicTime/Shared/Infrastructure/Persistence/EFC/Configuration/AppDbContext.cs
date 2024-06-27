using Backend_MusicTime.Musician.Domain.Model.Aggregates;
using Backend_MusicTime.Contracts.Domain.Model.Aggregates;
using Backend_MusicTime.IAM.Domain.Model.Aggregates;
using Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend_MusicTime.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Customer.Domain.Model.Aggregates.Customer> Customers { get; set; }

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
                n.Property(m => m.FirstName).HasColumnName("FirstName");
                n.Property(m => m.LastName).HasColumnName("LastName");
            });

        // Contract Context
        builder.Entity<Contract>().HasKey(p => p.Id);
        builder.Entity<Contract>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Contract>().Property(p => p.EventDate).HasColumnType("datetime");
        builder.Entity<Contract>().OwnsOne(p => p.CustomerName,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(nc => nc.FirstName).HasColumnName("CustomerFirstName");
                n.Property(nc => nc.LastName).HasColumnName("CustomerLastName");
            });
        builder.Entity<Contract>().OwnsOne(p => p.MusicianName,
            m =>
            {
                m.WithOwner().HasForeignKey("Id");
                m.Property(pm => pm.FirstName).HasColumnName("MusicianFirstName");
                m.Property(pm => pm.LastName).HasColumnName("MusicianLastName");
            });
        builder.Entity<Contract>().OwnsOne(p => p.EventLocation,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("EventLocationStreet");
                a.Property(s => s.Number).HasColumnName("EventLocationNumber");
                a.Property(s => s.City).HasColumnName("EventLocationCity");
            });
        
        // Customers Context
        builder.Entity<Customer.Domain.Model.Aggregates.Customer>().HasKey(p => p.Id);
        builder.Entity<Customer.Domain.Model.Aggregates.Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer.Domain.Model.Aggregates.Customer>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });

        builder.Entity<Customer.Domain.Model.Aggregates.Customer>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

        builder.Entity<Customer.Domain.Model.Aggregates.Customer>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("AddressStreet");
                a.Property(s => s.Number).HasColumnName("AddressNumber");
                a.Property(s => s.City).HasColumnName("AddressCity");
                a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
                a.Property(s => s.Country).HasColumnName("AddressCountry");
            });
        
        
        //Enterprise Context
        
        builder.Entity<Enterprise.Domain.Model.Aggregates.Enterprise>().HasKey(p => p.Id);
        builder.Entity<Enterprise.Domain.Model.Aggregates.Enterprise>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Enterprise.Domain.Model.Aggregates.Enterprise>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.Name).HasColumnName("Name");
            });
        
        builder.Entity<Enterprise.Domain.Model.Aggregates.Enterprise>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });
        
        builder.Entity<Enterprise.Domain.Model.Aggregates.Enterprise>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("AddressStreet");
                a.Property(s => s.Number).HasColumnName("AddressNumber");
                a.Property(s => s.City).HasColumnName("AddressCity");
                a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
                a.Property(s => s.Country).HasColumnName("AddressCountry");
            });
        
        
        // IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();


        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}