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
        public virtual DbSet<Routine> Routines { get; set; }
        public virtual DbSet<Routinemechanic> Routinemechanic { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Workshops> Workshops { get; set; }
        public virtual DbSet<ReferenceBrand> ReferenceBrands { get; set; }
        public virtual DbSet<RoutineBrand> RoutineBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if(modelBuilder != null)
            {
                modelBuilder.Entity<Appointment>(entity => {
                    entity.Property(b => b.Fhcreated)
                    .HasDefaultValueSql("now()");
                    entity.Property(b => b.Status)
                    .HasDefaultValueSql("0");

                    entity.HasOne<Maintenance>(m => m.Maintenance)
                    .WithOne(a => a.Appointments)
                    .HasForeignKey<Maintenance>(a => a.IdAppointment);

                    entity.HasOne<Workshops>(a => a.Workshops)
                    .WithMany(w => w.Appointments)
                    .HasForeignKey(a => a.WorkshopsId);
                });

                modelBuilder.Entity<Routinemechanic>(entity =>
                {
                    entity.HasNoKey();
                });
                modelBuilder.Entity<RoutineBrand>()
                    .HasKey(sc => new { sc.IdRoutine, sc.IdReferenceBrand });

                modelBuilder.Entity<RoutineBrand>()
                    .HasOne<ReferenceBrand>(sc => sc.ReferenceBrand)
                    .WithMany(s => s.RoutineBrand)
                    .HasForeignKey(sc => sc.IdReferenceBrand);

                modelBuilder.Entity<RoutineBrand>()
                    .HasOne<Routine>(sc => sc.Routine)
                    .WithMany(s => s.RoutineBrand)
                    .HasForeignKey(sc => sc.IdRoutine);

                modelBuilder.Entity<Maintenanceroutine>()
                    .HasKey(sc => new { sc.IdMechanic, sc.IdMaintenance });

                modelBuilder.Entity<Maintenanceroutine>()
                    .HasOne<Maintenance>(m => m.Maintenances)
                    .WithMany(s => s.Maintenanceroutines)
                    .HasForeignKey(m => m.IdMaintenance);

                modelBuilder.Entity<Maintenanceroutine>()
                   .HasOne<Mechanics>(m => m.Mechanics)
                   .WithMany(s => s.Maintenanceroutines)
                   .HasForeignKey(m => m.IdMechanic);

                modelBuilder.Entity<Vehicles>()
                    .HasOne<Maintenance>(v => v.Maintenances)
                    .WithMany(m => m.Vehicles)
                    .HasForeignKey(v => v.Id);
                //modelBuilder.Entity<RoutineBrand>(entity =>
                //{
                //    entity.HasNoKey();
                //})

                //modelBuilder.Entity<Maintenanceroutine>(entity =>
                //{
                //    entity.HasNoKey();
                //});

                modelBuilder.Entity<Routine>(entity => 
                {
                    entity.Property(b => b.Fhcreated)
                    .HasDefaultValueSql("now()");
                    entity.Property(b => b.Status)
                    .HasDefaultValueSql("1");
                    entity.Property(b => b.IdRoutine).UseIdentityColumn();
                });

                modelBuilder.Entity<Maintenance>(entity =>
                {
                    entity.Property(b => b.Fhcreated)
                    .HasDefaultValueSql("now()");
                    entity.Property(b => b.Status)
                    .HasDefaultValueSql("1");
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
