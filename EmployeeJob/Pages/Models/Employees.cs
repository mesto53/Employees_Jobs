using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeJob.Pages.Models
{
    public class Employees
    {
        [Key]
        public int Eid { get; set; }


        [Required]
        [Display(Name = "Name    :   ")]
        public string Name { get; set; } = "";


        [Required]
        [Display(Name = "BirthDate    :   ")]
        public DateTime BirthDate { get; set; }


        [Required]
        [Display(Name = "Phone Number    :   ")]
        public int? Phone { get; set; }
           
        
        [Display(Name = "UPLOAD PHOTO    :   ")]
        public string PersonalPhoto { get; set; } = "";
        
        
        [Required]
        [Display(Name = "Employment Date    :   ")]
        public DateTime EmploymentDate { get; set; }
        
        
        [Required]
        [Display(Name = "Governorate    :   ")]
        
        public string Governorate { get; set; } = "";


        [Display(Name = "IsProbation")]
        public bool IsProbation { get; set; }
            
        public bool IsDeleted { get; set; } = false;

    }
}
