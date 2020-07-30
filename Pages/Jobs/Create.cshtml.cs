using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobTrackingApp.Pages.Jobs
{
    public class CreateModel : PageModel
    {
        private readonly JobTrackingApp.Data.JobsContext _context;

        public CreateModel(JobTrackingApp.Data.JobsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobsModel JobsModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobsModel.Add(JobsModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
