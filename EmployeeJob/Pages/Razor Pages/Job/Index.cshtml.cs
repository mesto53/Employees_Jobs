using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace EmployeeJob.Pages.Razor_Pages.Job
{ 

    public class IndexModel : PageModel
    {
        public List<Jobs> Jobs { get; set; }
        [BindProperty(SupportsGet = true)]
        public string jobFilter { get; set; } = "";
        public List<string>? Employees { get; set; }
        public EmployeeJobServices EJServices { get; set; }
        public JobService JobService { get; set; }  
        private Context Context { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? JobId { get; set; }

        public IndexModel(Context Context,EmployeeJobServices employeejobService,JobService jobService)
        {
            this.JobService = jobService;
            this.Context = Context;
            this.EJServices = employeejobService;
        }
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(jobFilter))
            {
                Jobs= await JobService.filter_By_Name(jobFilter);
             }
            else
            {
                Jobs = await JobService.getallJobs();
            }
            if (JobId.HasValue)
            {
                Employees = await EJServices.getAllEmployees_withId(JobId);
            }
            
        }
    }
}