using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeJob.Pages.Razor_Pages.Employee
{
    public class RorDModel : PageModel
    {
            public List<Employees> Employees { get; set; }


            [BindProperty(SupportsGet = true)]
            public string EmployeeFilter { get; set; } = "";


            public EmployeeService EmployeeService { get; set; }


            [BindProperty(SupportsGet = true)]
            public int? EmployeeId { get; set; }


            [BindProperty(SupportsGet = true)]
            public int? type { get; set; }


            public RorDModel(EmployeeService employeeService)
            {
                this.EmployeeService = employeeService;
            }
            public async Task OnGetAsync()
            {
                if (!string.IsNullOrEmpty(EmployeeFilter))
                {
                    Employees = await EmployeeService.filter_By_NameDELTED(EmployeeFilter);
                }
                else
                {
                    Employees = await EmployeeService.getallDeletedJob();
                }
                if (EmployeeId.HasValue && type.HasValue)
                {
                    if (type == 0)
                    {
                        await this.EmployeeService.DeleteEmployee(EmployeeId);
                        Employees = await EmployeeService.getallDeletedJob();
                    }
                    else
                    {
                        await this.EmployeeService.FindAndUpdate(EmployeeId);
                        Employees = await EmployeeService.getallDeletedJob();
                    }
                }

            }
        }
    }

