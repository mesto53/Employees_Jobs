using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeJob.Pages.Razor_Pages.Employee
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Employees employee { get; set; }

        public EmployeeService EmployeeService { get; set; }
        public EmployeeJobServices EmployeeJobServices { get; set; }
        public DeleteModel(EmployeeService employeeService,EmployeeJobServices employeeJobServices) 
        {
           this.EmployeeService = employeeService; 
            this.EmployeeJobServices = employeeJobServices;
        }
        public async Task OnGetAsync(int id)
        {
            this.employee = await EmployeeService.getEmployee_ById(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            this.employee = await EmployeeService.getEmployee_ById(employee.Eid);
            bool ej = await EmployeeJobServices.Get_EJ_By_Eid(employee);
            if (ej == false)
            {
                this.employee.IsDeleted = true;
                await this.EmployeeService.UpdateEmployee(this.employee);
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
