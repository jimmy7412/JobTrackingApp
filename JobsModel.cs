using System;
using System.Collections.Generic;

namespace JobTrackingApp
{
    public class JobsModel
    {
        public int ID { get; set; }
        public string company { get; set; }
        public string title { get; set; }
        public string job_number { get; set; }
        public DateTime last_checked { get; set; }
        public DateTime last_updated { get; set; }
        public DateTime date_applied { get; set; }
        public string status { get; set; }
        public string notes { get; set; }
        public bool interview { get; set; }
        public bool rejected { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}