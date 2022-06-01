using CentiroAssignment.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiroAssignment.Data
{
    public class CentiroAssignmentDbContext : DbContext
    {
        public CentiroAssignmentDbContext(DbContextOptions<CentiroAssignmentDbContext> options)
            : base(options)
        {
            ;
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CentiroAssignmentDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
