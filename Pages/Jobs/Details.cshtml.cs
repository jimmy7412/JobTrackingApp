using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly JobTrackingApp.Data.JobsContext _context;

        public DetailsModel(JobTrackingApp.Data.JobsContext context)
        {
            _context = context;
        }

        public JobsModel JobsModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobsModel = await _context.JobsModel.FirstOrDefaultAsync(m => m.ID == id);

            if (JobsModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
