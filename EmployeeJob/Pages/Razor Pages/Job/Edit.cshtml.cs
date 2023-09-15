using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeJob.Pages.Razor_Pages.Job
{
    public class EditModel : PageModel
    {
        private readonly Context _context;
        public JobService JobService { get; set; }
        [BindProperty]
        public Jobs Job { get; set; }
        public EditModel(Context context,Jobs Job,JobService jobService) 
        { 
           this._context = context;
            this.Job = Job;
            this.JobService = jobService;
        }
        public async Task OnGetAsync(int id)
        { 
            Job = await JobService.GetJobById(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await JobService.UpdateDb(Job);
            return RedirectToPage("./Index");
        }
    }
}
