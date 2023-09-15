using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EmployeeJob.Pages.Razor_Pages.Job
{
        public class CreateModel : PageModel
        {
            [BindProperty]
            public Jobs Job { get; set; }
            public JobService JobService { get; set; }
            private Context Context { get; set; }

            public CreateModel(Context Context, JobService jobService,Jobs jobs)
            {
                this.Context = Context;
                this.JobService = jobService;
                this.Job = jobs;
            }
             public void OnGet() { }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                await this.JobService.AddToDb(Job);
                return RedirectToPage("./Index");
            }
        }
}
