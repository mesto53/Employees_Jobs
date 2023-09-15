using EmployeeJob.Pages.Models;
using EmployeeJob.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EmployeeJob.Pages.Razor_Pages.Employee
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Employees Employee { get; set; }
        [BindProperty]
        [Required]
        [Display(Name = "Upload photo")]
        public IFormFile Photo { get; set; }
        public EmployeeService EmployeeService { get; set; }
        public string validate = "^(?:(0?[1-3-5-7-9]|70|71|76|78|79|81)\\d{6})$";
        public CreateModel(Employees employees,EmployeeService employeeService) 
        {
            this.EmployeeService = employeeService;
            this.Employee = employees;
            employees.BirthDate = DateTime.Now;
            employees.Phone = null;
            employees.EmploymentDate = DateTime.Now;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!Regex.IsMatch((Employee.Phone).ToString(), validate))
            {
                ModelState.AddModelError("", "phone number should be lebanese number");
            }
            if (!ModelState.IsValid)
            {
                return Page(); 
            }
            this.Employee =  this.EmployeeService.AddPhoto(Photo, this.Employee);
            await this.EmployeeService.AddEmployee(this.Employee);
            return RedirectToPage("./Index");
        }

    }
}
