using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.Pages.Jobs
{
    public class DeleteModel : PageModel
    {
        private readonly JobTrackingApp.Data.JobsContext _context;

        public DeleteModel(JobTrackingApp.Data.JobsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobsModel = await _context.JobsModel.FindAsync(id);

            if (JobsModel != null)
            {
                _context.JobsModel.Remove(JobsModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
