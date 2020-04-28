using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL
{
    public class RepositoryContextPostgresql : DbContext
    {
        public RepositoryContextPostgresql()
        {

        }
        public RepositoryContextPostgresql(DbContextOptions options)
            : base(options) 
        {
        
        }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Maintenance> Maintenance { get; set; }
        public virtual DbSet<Maintenancerating> Maintenancerating { get; set; }
        public virtual DbSet<Maintenanceroutine> Maintenanceroutine { get; set; }
        public virtual DbSet<Mechanics> Mechanics { get; set; }
        public virtual DbSet<Routine> Routine { get; set; }
        public virtual DbSet<Routinemechanic> Routinemechanic { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Workshops> Workshops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if(modelBuilder != null)
            {
                modelBuilder.Entity<Appointment>(entity => {
                    entity.Property(b => b.Fhcreated)
                    .HasDefaultValueSql("now()");
                    entity.Property(b => b.Status)
                    .HasDefaultValueSql("1");
                });
                modelBuilder.Entity<Maintenanceroutine>(entity =>
                {
                    entity.HasNoKey();
                });
                modelBuilder.Entity<Routinemechanic>(entity =>
                {
                    entity.HasNoKey();
                });
                modelBuilder.Entity<Routine>(entity => 
                {
                    entity.Property(b => b.Fhcreated)
                    .HasDefaultValueSql("now");
                    entity.Property(b => b.Status)
                    .HasDefaultValueSql("1");
                    entity.Property(b => b.Idroutine).UseIdentityColumn();
                });
                modelBuilder.HasAnnotation("Sqlite:Autoincrement", true)
                   .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                   .HasAnnotation("Npgsql:ValueGenerationStrategy",
                    Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                   .HasAnnotation("SqlServer:ValueGenerationStrategy", Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.IdentityColumn);
                }
        }
    }
}
