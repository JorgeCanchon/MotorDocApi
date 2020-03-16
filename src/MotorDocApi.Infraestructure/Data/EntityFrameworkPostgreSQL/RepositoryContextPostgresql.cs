using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorDocApi.Infraestructure.EntityFrameworkPostgreSQL
{
    public class RepositoryContextPostgresql : DbContext
    {
        public RepositoryContextPostgresql(DbContextOptions options)
            : base(options) 
        {
        
        }
        #region DbSets
        DbSet<User> users { get; set; }
        #endregion

        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    optionBuilder.UseNpgsql("Host=ec2-52-73-247-67.compute-1.amazonaws.com;Database=d8e81j1jlb7c16;Username=hyrjphcachsrpy;Password=1ef60c7ca1d1737639e27fcfd40b3b7cb65669499cdc7baefa85e76274c92043;sslmode=Require;Trust Server Certificate=true;");
        //}
    }
}
