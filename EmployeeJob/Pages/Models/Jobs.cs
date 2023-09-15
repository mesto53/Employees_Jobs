using System.ComponentModel.DataAnnotations;

namespace EmployeeJob.Pages.Models
{

    public class Jobs
    {
        [Key] 
        public int JId { get; set; }


        [Required]
        [Display(Name = "Name    :   ")]
        public string Name { get; set; } = "";


        [Required]
        [Display(Name = "Gategory    :   ")]
        public string Category { get; set; } = "";


        public bool isDelete { set; get; }
    }
}
