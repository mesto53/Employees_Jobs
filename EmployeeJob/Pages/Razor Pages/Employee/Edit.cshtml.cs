using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeJob.Pages.Razor_Pages.Employee
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Employees Employee { get; set; }

        [BindProperty]
        [Display(Name = "Upload photo")]
        public IFormFile? Photo { get; set; }
        public EmployeeService EmployeeService { get; set; }
        public string validate = "^(?:(0?[1-3-5-7-9]|70|71|76|78|79|81)\\d{6})$";
        public EditModel(Employees employees, EmployeeService employeeService)
        {
            this.EmployeeService = employeeService;
            this.Employee = employees;
        }
        public async Task OnGetAsync(int id)
        {
            Employee = await this.EmployeeService.getEmployee_ById(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!Regex.IsMatch((Employee.Phone).ToString(), validate))
            {
                ModelState.AddModelError("", "phone number should be lebanese number");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Photo != null)
            {
                this.Employee = this.EmployeeService.AddPhoto(Photo, this.Employee);
            }
            await this.EmployeeService.UpdateEmployee(this.Employee);
            return RedirectToPage("./Index");
        }

    }
}

