using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly JobTrackingApp.Data.JobsContext _context;

        public EditModel(JobTrackingApp.Data.JobsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(JobsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobsModelExists(JobsModel.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobsModelExists(int id)
        {
            return _context.JobsModel.Any(e => e.ID == id);
        }
    }
}
