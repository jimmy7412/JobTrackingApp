using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobTrackingApp;

namespace JobTrackingApp.Data
{
    public class JobsContext : DbContext
    {
        public JobsContext (DbContextOptions<JobsContext> options)
            : base(options)
        {
        }

        public DbSet<JobTrackingApp.JobsModel> JobsModel { get; set; }
    }
}
