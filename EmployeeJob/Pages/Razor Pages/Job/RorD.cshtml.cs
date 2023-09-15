using EmployeeJob.Pages.Database;
using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeJob.Pages.Razor_Pages.Job
{
    public class RorDModel : PageModel
    {
        public List<Jobs> Jobs { get; set; }
        
        
        [BindProperty(SupportsGet = true)]
        public string jobFilter { get; set; } = "";


        public JobService JobService { get; set; }


        [BindProperty(SupportsGet = true)]
        public int? JobId { get; set; }


        [BindProperty(SupportsGet = true)]
        public int? type { get; set; }


        public RorDModel( JobService jobService)
        {
            this.JobService = jobService;
    
        }
        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(jobFilter))
            {
                Jobs = await JobService.filter_By_NameDELTED(jobFilter);
            }
            else
            {
                Jobs = await JobService.getallDeletedJob();
            }
            if (JobId.HasValue && type.HasValue)
            {
                if (type == 0)
                {
                    await this.JobService.DeleteJob(JobId);
                    Jobs = await JobService.getallDeletedJob();
                }
                else
                {
                    await this.JobService.FindAndUpdate(JobId);
                    Jobs = await JobService.getallDeletedJob();
                }
            }

        }
    }
}
