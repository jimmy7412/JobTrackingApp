using System;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp
{
    public class JobsApplied : DbContext 
    {
        public JobsApplied (DbContextOptions<JobsApplied> options) : base(options)
        {
        }
        
        public DbSet<JobsModel> JobsModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobsModel>().ToTable("JobsModel");
        }
    }
}