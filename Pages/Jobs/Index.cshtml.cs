using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackingApp.Data.JobsContext _context;

        public IndexModel(JobTrackingApp.Data.JobsContext context)
        {
            _context = context;
        }

        public IList<JobsModel> JobsModel { get;set; }

        public async Task OnGetAsync()
        {
            JobsModel = await _context.JobsModel.ToListAsync();
        }
    }
}
