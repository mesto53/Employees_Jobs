using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeJob.Pages.Models
{
        public class EJ
        {

            [Key]
            public int Eid { get; set; }
            public int Jid { get; set; } 
            
    }
}
