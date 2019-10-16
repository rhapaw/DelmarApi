using Delmar1Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Delmar1Api.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<BuildingClass> BuildingClasses { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyAndUserLink> PropertyAndUserLinks { get; set; }

        public DbSet<PropertyPicture> PropertyPictures { get; set; }

        public DbSet<PropertySubType> PropertySubTypes { get; set; }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<SaleType> SaleTypes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BuildingClass>()
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(24);

            builder.Entity<Property>()
                .Property(p => p.PurchasePrice)
                .IsRequired();


            builder.Entity<Property>()
                .HasOne(t => t.PropertyType)
                .WithMany()
                .HasForeignKey(k => k.PropertyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Property>()
                .HasOne(t => t.PropertySubType)
                .WithMany()
                .HasForeignKey(k => k.PropertySubTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Property>()
                .HasOne(t => t.SaleType)
                .WithMany()
                .HasForeignKey(k => k.SaleTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PropertyAndUserLink>()
                .HasKey(k => new { k.PropertyId, k.UserId });
                
            builder.Entity<PropertyAndUserLink>()
                .HasOne(u => u.User)
                .WithMany(k => k.PropertyLinks)
                .HasForeignKey(k => k.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PropertyAndUserLink>()
                .HasOne(p => p.Property)
                .WithMany(k => k.UserLinks)
                .HasForeignKey(k => k.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PropertyPicture>()
                .HasOne(u => u.Property)
                .WithMany(k => k.PropertyPictures)
                .HasForeignKey(k => k.PropertyId);

            builder.Entity<PropertySubType>()
                .HasOne(u => u.PropertyType)
                .WithMany(k => k.PropertySubTypes)
                .HasForeignKey(k => k.PropertyTypeId);

        }

    }

}


