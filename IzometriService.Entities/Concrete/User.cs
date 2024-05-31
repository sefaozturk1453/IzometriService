using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IzometriService.Entities.Concrete
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public int? DepartmentsId { get; set; }

        public Department Departments { get; set; }
    }
}
