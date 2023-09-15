using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeJob.Pages.Razor_Pages.Job
{
    public class DeleteModel : PageModel
    {
        private Context Context { get; set; }
        [BindProperty]
        public Jobs Job { get; set; }
        public JobService JobService { get; set; }
        public EmployeeJobServices Services { get; set; }
        public DeleteModel(Context context, JobService jobService, Jobs Job,EmployeeJobServices employeeJobServices) 
        { 
            this.Context = context;
            this.JobService = jobService;
            this.Job = Job;
            this.Services = employeeJobServices;
        }
        public async Task OnGetAsync(int id)
        {
            Job = await this.JobService.GetJobById(id);

        }
        public async Task<IActionResult> OnPostAsync()
        {
            bool ej = await Services.Get_EJ_By_JId(Job);
            if (ej == false)
            {
                Job.isDelete = true;
                await this.JobService.UpdateDb(Job);
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError("", "This job has Employees you can't delete"); 
            }
            return Page();
         
        }
    }
}
