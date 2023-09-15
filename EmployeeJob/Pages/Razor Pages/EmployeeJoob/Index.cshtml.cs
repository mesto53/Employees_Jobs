using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace EmployeeJob.Pages.Razor_Pages.EmployeeJoob
{
    public class IndexModel : PageModel
    {
        public Employees employees {  get; set; }
        
        public List<Jobs> jobs { get; set; }

        public List<Jobs> EmployeeJob { get; set; }
        
        public EmployeeService employeeService { get; set; }
        
        public JobService jobService { get; set; }
        
        public EmployeeJobServices EmployeeJobServices { get; set; }
        
        [Required]
        [BindProperty]
        public string JobName { get; set; }

        [BindProperty]
        public int Eid { get; set; }

        public IndexModel(Employees employees,EmployeeService employeeService,JobService jobService,EmployeeJobServices employeeJobServices)
        {
            this.EmployeeJobServices = employeeJobServices;
            this.employees = employees;
            this.jobService = jobService;
            this.employeeService = employeeService;
           
        }
        public async Task OnGet(int id)
        {
            employees = await employeeService.getEmployee_ById(id);
            jobs = await jobService.getallJobs();
            EmployeeJob = await EmployeeJobServices.get_Employee_Jobs(id);
            this.Eid = employees.Eid;
        }

        public async Task<IActionResult> OnPostAddJob()
        {
            if (ModelState.IsValid)
            {
                await this.EmployeeJobServices.AddEmployeeJob(JobName,Eid);
            }
            return RedirectToPage("/Razor Pages/Employee/Index");
        }


        public async Task<IActionResult> OnPostDelete(int Jid)
        {
            await this.EmployeeJobServices.DeleteEmployeeJob(Jid, Eid);
            return RedirectToPage("/Razor Pages/Employee/Index");
        }
    }
}
