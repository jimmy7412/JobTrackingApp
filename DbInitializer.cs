using System;
using System.Linq;

namespace JobTrackingApp
{
    public static class DbInitializer
    {
        public static void Initialize(JobsApplied jobsApplied)
        {
            jobsApplied.Database.EnsureCreated();

            if (jobsApplied.JobsModel.Any())
            {
                return;
            }

            var jobs = new JobsModel[]
            {
                new JobsModel
                {
                    ID = 1, company = "Amazon", title = "Software Engineer", job_number = "000001",
                    last_checked = DateTime.Parse("2020-05-01"), last_updated = DateTime.Parse("2020-04-01"),
                    date_applied = DateTime.Parse("2020-03-01"), status = "Active", notes = "Still Active",
                    interview = true, rejected = false, city = "Seattle", state = "Washington",
                    country = "United States"
                }
            };

            jobsApplied.JobsModel.AddRange(jobs);
            jobsApplied.SaveChanges();
        }
    }
}