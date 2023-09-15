using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeJob.Pages.Razor_Pages.Employee
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string EmployeeFilter { get; set; } = "";
        EmployeeService EmployeeService { get; set; }
        

        public IndexModel(EmployeeService employeeService)
        {
            this.EmployeeService = employeeService;
        }

        public List<Employees> Employees { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(EmployeeFilter))
            {
                Employees = await EmployeeService.filter(EmployeeFilter);
            }
            else
            {
                Employees = await EmployeeService.getAllEmployees();
            }
            
        }
    }
}
